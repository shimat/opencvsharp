﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect2f : IEquatable<Rect2f>
    {
        #region Field
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        /// <summary>
        /// 
        /// </summary>
        public float Width;
        /// <summary>
        /// 
        /// </summary>
        public float Height;
        /// <summary>
        /// sizeof(Rect)
        /// </summary>
        public const int SizeOf = sizeof(float) * 4;

#if LANG_JP
        /// <summary>
        /// プロパティを初期化しない状態の Rect2f 構造体を表します。 
        /// </summary>
#else
        /// <summary>
        /// Represents a Rect2f structure with its properties left uninitialized. 
        /// </summary>
#endif
        public static readonly Rect2f Empty = new Rect2f();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rect2f(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public Rect2f(Point2f location, Size2f size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.Width;
            Height = size.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public static Rect2f FromLTRB(float left, float top, float right, float bottom)
        {
            var r = new Rect2f
            {
                X = left,
                Y = top,
                Width = right - left + 1,
                Height = bottom - top + 1
            };

            if (r.Width < 0)
                throw new ArgumentException("right > left");
            if (r.Height < 0)
                throw new ArgumentException("bottom > top");
            return r;
        }

        #region Operators
        #region == / !=
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトと等しければtrueを返す 
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns>型が同じで、メンバの値が等しければtrue</returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public bool Equals(Rect2f obj)
        {
            return (Math.Abs(X - obj.X) < 1e-9 && 
                    Math.Abs(Y - obj.Y) < 1e-9 &&
                    Math.Abs(Width - obj.Width) < 1e-9 && 
                    Math.Abs(Height - obj.Height) < 1e-9);
        }

#if LANG_JP
        /// <summary>
        /// == 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two Rectf objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(Rect2f lhs, Rect2f rhs)
        {
            return lhs.Equals(rhs);
        }

#if LANG_JP
        /// <summary>
        /// != 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two Rectf objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
#endif
        public static bool operator !=(Rect2f lhs, Rect2f rhs)
        {
            return !lhs.Equals(rhs);
        }
        #endregion
        #region + / -
#if LANG_JP
        /// <summary>
        /// あるオフセットで矩形を移動させる
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Shifts rectangle by a certain offset
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
#endif
        public static Rect2f operator +(Rect2f rect, Point2f pt)
        {
            return new Rect2f(rect.X + pt.X, rect.Y + pt.Y, rect.Width, rect.Height);
        }
#if LANG_JP
        /// <summary>
        /// あるオフセットで矩形を移動させる
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Shifts rectangle by a certain offset
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
#endif
        public static Rect2f operator -(Rect2f rect, Point2f pt)
        {
            return new Rect2f(rect.X - pt.X, rect.Y - pt.Y, rect.Width, rect.Height);
        }

#if LANG_JP
        /// <summary>
        /// 指定したサイズ応じて、矩形を膨張または縮小する
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="size"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Expands or shrinks rectangle by a certain amount
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="size"></param>
        /// <returns></returns>
#endif
        public static Rect2f operator +(Rect2f rect, Size2f size)
        {
            return new Rect2f(rect.X, rect.Y, rect.Width + size.Width, rect.Height + size.Height);
        }
#if LANG_JP
        /// <summary>
        /// 指定したサイズ応じて、矩形を膨張または縮小する
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="size"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Expands or shrinks rectangle by a certain amount
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="size"></param>
        /// <returns></returns>
#endif
        public static Rect2f operator -(Rect2f rect, Size2f size)
        {
            return new Rect2f(rect.X, rect.Y, rect.Width - size.Width, rect.Height - size.Height);
        }
        #endregion
        #region & / |
#if LANG_JP
        /// <summary>
        /// 2つの矩形の交差部分を表す矩形を取得する
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines the Rect2f structure that represents the intersection of two rectangles. 
        /// </summary>
        /// <param name="a">A rectangle to intersect. </param>
        /// <param name="b">A rectangle to intersect. </param>
        /// <returns></returns>
#endif
        public static Rect2f operator &(Rect2f a, Rect2f b)
        {
            return Intersect(a, b);
        }

#if LANG_JP
        /// <summary>
        /// 2つの矩形の和集合を表す矩形を取得する 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Gets a Rect2f structure that contains the union of two Rect2f structures. 
        /// </summary>
        /// <param name="a">A rectangle to union. </param>
        /// <param name="b">A rectangle to union. </param>
        /// <returns></returns>
#endif
        public static Rect2f operator |(Rect2f a, Rect2f b)
        {
            return Union(a, b);
        }
        #endregion
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 上端のy座標 
        /// </summary>
#else
        /// <summary>
        /// Gets the y-coordinate of the top edge of this Rect2f structure. 
        /// </summary>
#endif
        public float Top
        {
            get { return Y; }
            set { Y = value; }
        }

#if LANG_JP
        /// <summary>
        /// 下端のy座標 (Y + Height) 
        /// </summary>
#else
        /// <summary>
        /// Gets the y-coordinate that is the sum of the Y and Height property values of this Rect2f structure.
        /// </summary>
#endif
        public float Bottom
        {
            get { return Y + Height - 1; }
        }

#if LANG_JP
        /// <summary>
        /// 左端のx座標
        /// </summary>
#else
        /// <summary>
        /// Gets the x-coordinate of the left edge of this Rect2f structure. 
        /// </summary>
#endif
        public float Left
        {
            get { return X; }
            set { X = value; }
        }

#if LANG_JP
        /// <summary>
        /// 右端のx座標 (X + Width)
        /// </summary>
#else
        /// <summary>
        /// Gets the x-coordinate that is the sum of X and Width property values of this Rect2f structure. 
        /// </summary>
#endif
        public float Right
        {
            get { return X + Width - 1; }
        }

#if LANG_JP
        /// <summary>
        /// 矩形の左上頂点の位置 [Point2f(X, Y)]
        /// </summary>
#else
        /// <summary>
        /// Coordinate of the left-most rectangle corner [Point2f(X, Y)]
        /// </summary>
#endif
        public Point2f Location
        {
            get { return new Point2f(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

#if LANG_JP
        /// <summary>
        /// 矩形の大きさ [CvSize(Width, Height)]
        /// </summary>
#else
        /// <summary>
        /// Size of the rectangle [CvSize(Width, Height)]
        /// </summary>
#endif
        public Size2f Size
        {
            get { return new Size2f(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

#if LANG_JP
        /// <summary>
        /// 左上の頂点
        /// </summary>
#else
        /// <summary>
        /// Coordinate of the left-most rectangle corner [Point2f(X, Y)]
        /// </summary>
#endif
        public Point2f TopLeft
        {
            get { return new Point2f(X, Y); }
        }

#if LANG_JP
        /// <summary>
        /// 右下の頂点
        /// </summary>
#else
        /// <summary>
        /// Coordinate of the right-most rectangle corner [Point2f(X+Width, Y+Height)]
        /// </summary>
#endif
        public Point2f BottomRight
        {
            get { return new Point2f(X + Width - 1, Y + Height - 1); }
        }
        #endregion

        #region Methods

#if LANG_JP
        /// <summary>
        /// 指定した点がこの矩形に含まれているかどうかを判断する
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
        /// </summary>
        /// <param name="x">x-coordinate of the point</param>
        /// <param name="y">y-coordinate of the point</param>
        /// <returns></returns>
#endif
        public bool Contains(float x, float y)
        {
            return (X <= x && Y <= y && X + Width - 1 > x && Y + Height - 1 > y);
        }

#if LANG_JP
        /// <summary>
        /// 指定した点がこの矩形に含まれているかどうかを判断する
        /// </summary>
        /// <param name="pt">点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
        /// </summary>
        /// <param name="pt">point</param>
        /// <returns></returns>
#endif
        public bool Contains(Point2f pt)
        {
            return Contains(pt.X, pt.Y);
        }

#if LANG_JP
        /// <summary>
        /// 指定した矩形がこの矩形に含まれているかどうかを判断する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines if the specified rectangle is contained within the rectangular region defined by this Rectangle. 
        /// </summary>
        /// <param name="rect">rectangle</param>
        /// <returns></returns>
#endif
        public bool Contains(Rect2f rect)
        {
            return X <= rect.X &&
                   (rect.X + rect.Width) <= (X + Width) &&
                   Y <= rect.Y &&
                   (rect.Y + rect.Height) <= (Y + Height);
        }

#if LANG_JP
        /// <summary>
        /// このRect2fを指定の量だけ膨らませる 
        /// </summary>
        /// <param name="width">水平方向の膨張量</param>
        /// <param name="height">垂直方向の膨張量</param>
#else
        /// <summary>
        /// Inflates this Rect by the specified amount. 
        /// </summary>
        /// <param name="width">The amount to inflate this Rectangle horizontally. </param>
        /// <param name="height">The amount to inflate this Rectangle vertically. </param>
#endif
        public void Inflate(float width, float height)
        {
            X -= width;
            Y -= height;
            Width += (2 * width);
            Height += (2 * height);
        }

#if LANG_JP
        /// <summary>
        /// このRect2fを指定の量だけ膨らませる 
        /// </summary>
        /// <param name="size">この四角形の膨張量</param>
#else
        /// <summary>
        /// Inflates this Rect by the specified amount. 
        /// </summary>
        /// <param name="size">The amount to inflate this rectangle. </param>
#endif
        public void Inflate(Size2f size)
        {

            Inflate(size.Width, size.Height);
        }

#if LANG_JP
        /// <summary>
        /// このRect2fを指定の量だけ膨らませる 
        /// </summary>
        /// <param name="rect">対象の矩形</param>
        /// <param name="x">水平方向の膨張量</param>
        /// <param name="y">垂直方向の膨張量</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates and returns an inflated copy of the specified Rect2f structure.
        /// </summary>
        /// <param name="rect">The Rectangle with which to start. This rectangle is not modified. </param>
        /// <param name="x">The amount to inflate this Rectangle horizontally. </param>
        /// <param name="y">The amount to inflate this Rectangle vertically. </param>
        /// <returns></returns>
#endif
        public static Rect Inflate(Rect rect, int x, int y)
        {
            rect.Inflate(x, y);
            return rect;
        }

#if LANG_JP
        /// <summary>
        /// 2つの矩形の交差部分を表す矩形を取得する
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines the Rect2f structure that represents the intersection of two rectangles. 
        /// </summary>
        /// <param name="a">A rectangle to intersect. </param>
        /// <param name="b">A rectangle to intersect. </param>
        /// <returns></returns>
#endif
        public static Rect2f Intersect(Rect2f a, Rect2f b)
        {
            var x1 = Math.Max(a.X, b.X);
            var x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Max(a.Y, b.Y);
            var y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
                return new Rect2f(x1, y1, x2 - x1, y2 - y1);
            return Empty;
        }

#if LANG_JP
        /// <summary>
        /// 2 つの矩形の交差部分を表す矩形を取得する
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines the Rect2f structure that represents the intersection of two rectangles. 
        /// </summary>
        /// <param name="rect">A rectangle to intersect. </param>
        /// <returns></returns>
#endif
        public Rect2f Intersect(Rect2f rect)
        {
            return Intersect(this, rect);
        }

#if LANG_JP
        /// <summary>
        /// 指定した矩形がこの矩形と交差するかどうか判定する
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Determines if this rectangle intersects with rect. 
        /// </summary>
        /// <param name="rect">Rectangle</param>
        /// <returns></returns>
#endif
        public bool IntersectsWith(Rect2f rect)
        {
            return (
                (X < rect.X + rect.Width) &&
                (X + Width > rect.X) &&
                (Y < rect.Y + rect.Height) &&
                (Y + Height > rect.Y)
            );
        }

#if LANG_JP
        /// <summary>
        /// 2つの矩形の和集合を表す矩形を取得する 
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Gets a Rect2f structure that contains the union of two Rect2f structures. 
        /// </summary>
        /// <param name="rect">A rectangle to union. </param>
        /// <returns></returns>
#endif
        public Rect2f Union(Rect2f rect)
        {
            return Union(this, rect);
        }

#if LANG_JP
        /// <summary>
        /// 2つの矩形の和集合を表す矩形を取得する 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Gets a Rect2f structure that contains the union of two Rect2f structures. 
        /// </summary>
        /// <param name="a">A rectangle to union. </param>
        /// <param name="b">A rectangle to union. </param>
        /// <returns></returns>
#endif
        public static Rect2f Union(Rect2f a, Rect2f b)
        {
            var x1 = Math.Min(a.X, b.X);
            var x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Min(a.Y, b.Y);
            var y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rect2f(x1, y1, x2 - x1, y2 - y1);
        }

#if LANG_JP
        /// <summary>
        /// Equalsのオーバーライド
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
#if LANG_JP
        /// <summary>
        /// GetHashCodeのオーバーライド
        /// </summary>
        /// <returns>このオブジェクトのハッシュ値を指定する整数値。</returns>
#else
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
#endif
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す 
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
        public override string ToString()
        {
            return $"(x:{X} y:{Y} width:{Width} height:{Height})";
        }

        #endregion
    }
}
