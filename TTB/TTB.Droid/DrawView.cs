using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace TTB.Droid
{
    // Original Source: http://csharp-tricks-en.blogspot.com/2014/05/android-draw-on-screen-by-finger.html
    public class DrawView : View
    {
        public DrawView(Context context)
            : base(context)
        {
            Start();
        }

        public float PenWidth { get; set; }

        private Path DrawPath;
        private Paint DrawPaint;
        private Paint CanvasPaint;
        private Canvas DrawCanvas;
        private Bitmap CanvasBitmap;

        private void Start()
        {
            PenWidth = 5.0f;

            DrawPath = new Path();
            DrawPaint = new Paint
            {
                Color = Color.Black,
                AntiAlias = true,
                StrokeWidth = PenWidth
            };

            DrawPaint.SetStyle(Paint.Style.Stroke);
            DrawPaint.StrokeJoin = Paint.Join.Round;
            DrawPaint.StrokeCap = Paint.Cap.Round;

            CanvasPaint = new Paint
            {
                Dither = true
            };
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            CanvasBitmap = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            DrawCanvas = new Canvas(CanvasBitmap);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            DrawPaint.Color = Color.Black;
            canvas.DrawBitmap(CanvasBitmap, 0, 0, CanvasPaint);
            canvas.DrawPath(DrawPath, DrawPaint);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            var touchX = e.GetX();
            var touchY = e.GetY();

            switch (e.Action)
            {
                case MotionEventActions.Down:
                    DrawPath.MoveTo(touchX, touchY);
                    break;
                case MotionEventActions.Move:
                    DrawPath.LineTo(touchX, touchY);
                    break;
                case MotionEventActions.Up:
                    DrawCanvas.DrawPath(DrawPath, DrawPaint);
                    break;
                default:
                    return false;
            }

            Invalidate();

            return true;
        }
    }
}