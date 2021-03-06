﻿//*** Guy Ronen © 2008-2011 ***//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Infrastructure.ObjectModel2D
{
    /// <summary>
    /// A class to assist with being able to nest game components inside of each other, provides support for all of the
    /// same functionality the game object performs on components with the addition of being neutral to where it resides
    /// in the hierarchy.
    /// </summary>
    public abstract class CompositeDrawableComponent<TComponentType> :
        DrawableGameComponent, ICollection<TComponentType>
        where TComponentType : IGameComponent
    {
        // the entire collection, for general collection methods (count, foreach, etc.):
        Collection<TComponentType> m_Components = new Collection<TComponentType>();

        #region Selective Collections
        // selective holders for specific operations each frame:
        private List<TComponentType> m_UninitializedComponents = new List<TComponentType>();
        protected List<IUpdateable> m_UpdateableComponents = new List<IUpdateable>();
        protected List<IDrawable> m_DrawableComponents = new List<IDrawable>();
        protected List<Sprite> m_Sprites = new List<Sprite>();
        #endregion //Selective Collections

        #region Events
        public event EventHandler<GameComponentEventArgs<TComponentType>> ComponentAdded;
        public event EventHandler<GameComponentEventArgs<TComponentType>> ComponentRemoved;
        #endregion //Events

        #region Add/Remove
        protected virtual void OnComponentAdded(GameComponentEventArgs<TComponentType> i_)
        {
            if (m_IsInitialized)
            {
                initializeComponent(i_.GameComponent);
            }
            else
            {
                m_UninitializedComponents.Add(i_.GameComponent);
            }

            // If the new component implements IUpdateable:
            // 1. find a spot for it on the updateable list 
            // 2. hook it's UpdateOrderChanged event
            IUpdateable updatable = i_.GameComponent as IUpdateable;
            if (updatable != null)
            {
                insertSorted(updatable);
                updatable.UpdateOrderChanged += new EventHandler<EventArgs>(childUpdateOrderChanged);
            }

            // If the new component implements IDrawable:
            // 1. find a spot for it on the drawable lists (IDrawble/Sprite) 
            // 2. hook it's DrawOrderChanged event
            IDrawable drawable = i_.GameComponent as IDrawable;
            if (drawable != null)
            {
                insertSorted(drawable);
                drawable.DrawOrderChanged += new EventHandler<EventArgs>(childDrawOrderChanged);
            }

            // raise the Added event:
            if (ComponentAdded != null)
            {
                ComponentAdded(this, i_);
            }
        }

        protected virtual void OnComponentRemoved(GameComponentEventArgs<TComponentType> i_)
        {
            if (!m_IsInitialized)
            {
                m_UninitializedComponents.Remove(i_.GameComponent);
            }

            IUpdateable updatable = i_.GameComponent as IUpdateable;
            if (updatable != null)
            {
                m_UpdateableComponents.Remove(updatable);
                updatable.UpdateOrderChanged -= childUpdateOrderChanged;
            }

            Sprite sprite = i_.GameComponent as Sprite;
            if (sprite != null)
            {
                m_Sprites.Remove(sprite);
                sprite.DrawOrderChanged -= childDrawOrderChanged;
            }

            else
            {
                IDrawable drawable = i_.GameComponent as IDrawable;
                if (drawable != null)
                {
                    m_DrawableComponents.Remove(drawable);
                    drawable.DrawOrderChanged -= childDrawOrderChanged;
                }
            }

            // raise the Removed event:
            if (ComponentRemoved != null)
            {
                ComponentRemoved(this, i_);
            }
        }

        /// <summary>
        /// When the update order of a component in this manager changes, will need to find a new place for it
        /// on the list of updateable components.
        /// </summary>
        private void childUpdateOrderChanged(object i_Sender, EventArgs i_)
        {
            IUpdateable updatable = i_Sender as IUpdateable;
            m_UpdateableComponents.Remove(updatable);

            insertSorted(updatable);
        }

        /// <summary>
        /// When the draw order of a component in this manager changes, will need to find a new place for it
        /// on the list of drawable components.
        /// </summary>
        private void childDrawOrderChanged(object i_Sender, EventArgs i_)
        {
            IDrawable drawable = i_Sender as IDrawable;

            Sprite sprite = i_Sender as Sprite;
            if (sprite != null)
            {
                m_Sprites.Remove(sprite);
            }
            else
            {
                m_DrawableComponents.Remove(drawable);
            }

            insertSorted(drawable);
        }

        public CompositeDrawableComponent(Game i_Game)
            : base(i_Game)
        { }

        private void insertSorted(IUpdateable i_Updatable)
        {
            int idx = m_UpdateableComponents.BinarySearch(i_Updatable, UpdateableComparer.r_Default);
            if (idx < 0)
            {
                idx = ~idx;
            }
            m_UpdateableComponents.Insert(idx, i_Updatable);
        }

        private void insertSorted(IDrawable i_Drawable)
        {
            Sprite sprite = i_Drawable as Sprite;
            if (sprite != null)
            {
                int idx = m_Sprites.BinarySearch(sprite, DrawableComparer<Sprite>.r_Default);
                if (idx < 0)
                {
                    idx = ~idx;
                }
                m_Sprites.Insert(idx, sprite);
            }
            else
            {
                int idx = m_DrawableComponents.BinarySearch(i_Drawable, DrawableComparer<IDrawable>.r_Default);
                if (idx < 0)
                {
                    idx = ~idx;
                }
                m_DrawableComponents.Insert(idx, i_Drawable);
            }
        }
        #endregion //Add/Remove

        #region Compoiste Drawbale Component
        private bool m_IsInitialized;

        /// <summary>
        /// initialize any component that haven't been initialized yet
        /// and remove it from the list of uninitialized components
        /// </summary>
        public override void Initialize()
        {
            if (!m_IsInitialized)
            {
                // Initialize any un-initialized game components
                while (m_UninitializedComponents.Count > 0)
                {
                    initializeComponent(m_UninitializedComponents[0]);
                }

                base.Initialize();

                m_IsInitialized = true;
            }
        }

        private void initializeComponent(TComponentType i_Component)
        {
            if (i_Component is Sprite)
            {
                (i_Component as Sprite).SpriteBatch = m_SpriteBatch;
            }

            i_Component.Initialize();
            m_UninitializedComponents.Remove(i_Component);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            m_SpriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (Sprite sprite in m_Sprites)
            {
                sprite.SpriteBatch = m_SpriteBatch;
            }
        }

        public override void Update(GameTime i_GameTime)
        {
            for (int i = 0; i < m_UpdateableComponents.Count; i++)
            {
                IUpdateable updatable = m_UpdateableComponents[i];
                if (updatable.Enabled)
                {
                    updatable.Update(i_GameTime);
                }
            }
        }

        public override void Draw(GameTime i_GameTime)
        {
            foreach (IDrawable drawable in m_DrawableComponents)
            {
                if (drawable.Visible)
                {
                    drawable.Draw(i_GameTime);
                }
            }

            m_SpriteBatch.Begin(
                SpritesSortMode, BlendState, SamplerState,
                DepthStencilState, RasterizerState, Shader, TransformMatrix);

            foreach (Sprite sprite in m_Sprites)
            {
                if (sprite.Visible)
                {
                    sprite.Draw(i_GameTime);
                }
            }
            m_SpriteBatch.End();
        }

        protected override void Dispose(bool i_Disposing)
        {
            if (i_Disposing)
            {
                // Dispose of components in this manager
                for (int i = 0; i < Count; i++)
                {
                    IDisposable disposable = m_Components[i] as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }

            base.Dispose(i_Disposing);
        }
        #endregion //Compoiste Drawbale Component

        #region ICollection<ComponentType> Implementations

        public virtual void Add(TComponentType i_Component)
        {
            InsertItem(m_Components.Count, i_Component);
        }

        protected virtual void InsertItem(int i_Idx, TComponentType i_Component)
        {
            if (m_Components.Contains(i_Component))
            {
                throw new ArgumentException("Duplicate components are not allowed in the same GameComponentManager.");
            }

            if (i_Component != null)
            {
                m_Components.Insert(i_Idx, i_Component);

                OnComponentAdded(new GameComponentEventArgs<TComponentType>(i_Component));
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                OnComponentRemoved(new GameComponentEventArgs<TComponentType>(m_Components[i]));
            }

            m_Components.Clear();
        }

        public bool Contains(TComponentType i_Component)
        {
            return m_Components.Contains(i_Component);
        }

        public void CopyTo(TComponentType[] i_IoComponentsArray, int i_ArrayIndex)
        {
            m_Components.CopyTo(i_IoComponentsArray, i_ArrayIndex);
        }

        public int Count
        {
            get { return m_Components.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public virtual bool Remove(TComponentType i_Component)
        {
            bool removed = m_Components.Remove(i_Component);

            if (i_Component != null && removed)
            {
                OnComponentRemoved(new GameComponentEventArgs<TComponentType>(i_Component));
            }

            return removed;
        }

        public IEnumerator<TComponentType> GetEnumerator()
        {
            return m_Components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_Components).GetEnumerator();
        }

        #endregion ICollection<ComponentType> Implementations

        #region SpriteBatch Advanced Support
        protected SpriteBatch m_SpriteBatch;
        public SpriteBatch SpriteBatch
        {
            get { return m_SpriteBatch; }
            set { m_SpriteBatch = value; }
        }

        protected BlendState m_BlendState = BlendState.AlphaBlend;
        public BlendState BlendState
        {
            get { return m_BlendState; }
            set { m_BlendState = value; }
        }

        protected SpriteSortMode m_SpritesSortMode = SpriteSortMode.Deferred;
        public SpriteSortMode SpritesSortMode
        {
            get { return m_SpritesSortMode; }
            set { m_SpritesSortMode = value; }
        }

        protected SamplerState m_SamplerState = null;
        public SamplerState SamplerState
        {
            get { return m_SamplerState; }
            set { m_SamplerState = value; }
        }

        protected DepthStencilState m_DepthStencilState = null;
        public DepthStencilState DepthStencilState
        {
            get { return m_DepthStencilState; }
            set { m_DepthStencilState = value; }
        }

        protected RasterizerState m_RasterizerState = null;
        public RasterizerState RasterizerState
        {
            get { return m_RasterizerState; }
            set { m_RasterizerState = value; }
        }

        protected Effect m_Shader = null;
        public Effect Shader
        {
            get { return m_Shader; }
            set { m_Shader = value; }
        }

        protected Matrix m_TransformMatrix = Matrix.Identity;
        public Matrix TransformMatrix
        {
            get { return m_TransformMatrix; }
            set { m_TransformMatrix = value; }
        }
        #endregion SpriteBatch Advanced Support

        #region Helping Properties
        protected Vector2 CenterOfViewPort
        {
            get
            {
                return new Vector2((float)Game.GraphicsDevice.Viewport.Width / 2, (float)Game.GraphicsDevice.Viewport.Height / 2);
            }
        }

        public ContentManager ContentManager
        {
            get { return Game.Content; }
        }
        #endregion Helping Properties
    }

    /// <summary>
    /// A comparer designed to assist with sorting IUpdateable interfaces.
    /// </summary>
    public sealed class UpdateableComparer : IComparer<IUpdateable>
    {
        /// <summary>
        /// A static copy of the comparer to avoid the GC.
        /// </summary>
        public static readonly UpdateableComparer r_Default;

        static UpdateableComparer() { r_Default = new UpdateableComparer(); }
        private UpdateableComparer() { }

        public int Compare(IUpdateable i_X, IUpdateable i_Y)
        {
            const int r_XBigger = 1;
            const int r_Equal = 0;
            const int r_YBigger = -1;

            int retCompareResult = r_YBigger;

            if (i_X == null && i_Y == null)
            {
                retCompareResult = r_Equal;
            }
            else if (i_X != null)
            {
                if (i_Y == null)
                {
                    retCompareResult = r_XBigger;
                }
                else if (i_X.Equals(i_Y))
                {
                    return r_Equal;
                }
                else if (i_X.UpdateOrder > i_Y.UpdateOrder)
                {
                    return r_XBigger;
                }
            }

            return retCompareResult;
        }
    }

    /// <summary>
    /// A comparer designed to assist with sorting IDrawable interfaces.
    /// </summary>
    public sealed class DrawableComparer<TDrawble> : IComparer<TDrawble>
        where TDrawble : class, IDrawable
    {
        /// <summary>
        /// A static copy of the comparer to avoid the GC.
        /// </summary>
        public static readonly DrawableComparer<TDrawble> r_Default;

        static DrawableComparer() { r_Default = new DrawableComparer<TDrawble>(); }
        private DrawableComparer() { }

        #region IComparer<IDrawable> Members

        public int Compare(TDrawble i_X, TDrawble i_Y)
        {
            const int r_XBigger = 1;
            const int r_Equal = 0;
            const int r_YBigger = -1;

            int retCompareResult = r_YBigger;

            if (i_X == null && i_Y == null)
            {
                retCompareResult = r_Equal;
            }
            else if (i_X != null)
            {
                if (i_Y == null)
                {
                    retCompareResult = r_XBigger;
                }
                else if (i_X.Equals(i_Y))
                {
                    return r_Equal;
                }
                else if (i_X.DrawOrder > i_Y.DrawOrder)
                {
                    return r_XBigger;
                }
            }

            return retCompareResult;
        }

        #endregion
    }

    /// <summary>
    /// Arguments used with events from the GameComponentCollection.
    /// </summary>
    /// <typeparam name="TComponentType"></typeparam>
    public class GameComponentEventArgs<TComponentType> : EventArgs
        where TComponentType : IGameComponent
    {
        private TComponentType m_Component;

        public GameComponentEventArgs(TComponentType i_GameComponent)
        {
            m_Component = i_GameComponent;
        }

        public TComponentType GameComponent
        {
            get { return m_Component; }
        }
    }
}