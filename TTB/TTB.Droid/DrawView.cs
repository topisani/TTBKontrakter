using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Support.Design.Widget;
using System.Collections.Generic;

namespace TTB.Droid
{
    public class DrawView : View
    {
        public DrawView(Context context)
            : base(context)
        {
            Start();
        }

        public float PenWidth { get; set; }

        private Path DrawPath;
        private List<PointD> Points;
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
            Points = new List<PointD>();
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            CanvasBitmap = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            DrawCanvas = new Canvas(CanvasBitmap);
            DrawCanvas.DrawARGB(255, 255, 255, 255);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            DrawPath = new Path();
            DrawPaint.Color = Color.Black;
            canvas.DrawBitmap(CanvasBitmap, 0, 0, CanvasPaint);
            if (Points.Count > 1)
            {
                for (int i = Points.Count - 2; i < Points.Count; i++)
                {
                    if (i >= 0)
                    {
                        PointD point = Points[i];

                        if (i == 0)
                        {
                            Point next = Points[i + 1];
                            point.dX = ((next.X - point.X) / 3);
                            point.dY = ((next.Y - point.Y) / 3);
                        }
                        else if (i == Points.Count - 1)
                        {
                            Point prev = Points[i - 1];
                            point.dX = ((point.X - prev.X) / 3);
                            point.dY = ((point.Y - prev.Y) / 3);
                        }
                        else
                        {
                            Point next = Points[i + 1];
                            Point prev = Points[i - 1];
                            point.dX = ((next.X - prev.X) / 3);
                            point.dY = ((next.Y - prev.Y) / 3);
                        }
                    }
                }
            }
            
            for (int i = 0; i < Points.Count; i++)
            {
                PointD point = Points[i];
                if (i == 0)
                {
                    DrawPath.MoveTo(point.X, point.Y);
                }
                else
                {
                    PointD prev = Points[i - 1];
                    DrawPath.CubicTo(prev.X + prev.dX, prev.Y + prev.dY, point.X - point.dX, point.Y - point.dY, point.X, point.Y);
                }
            }
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
                    Points.Add(new PointD((int)touchX, (int)touchY));
                    break;
                case MotionEventActions.Up:
                    DrawCanvas.DrawPath(DrawPath, DrawPaint);
                    Points.Clear();
                    break;
                default:
                    return false;
            }

            Invalidate();

            return true;
        }

        public string Save(string Filename)
        {
            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/" + Filename + ".png";
            System.IO.FileStream file = System.IO.File.Create(path);
            try
            {
                CanvasBitmap.Compress(Bitmap.CompressFormat.Png, 100, file);
                file.Flush();
                file.Close();
                Resource res = new Resource();
                Toast.MakeText(Context, Resource.String.image_saved, ToastLength.Long).Show();
            }
            catch (Exception e)
            {
                Toast.MakeText(Context, Resource.String.image_save_error, ToastLength.Long).Show();
            }
            return path;
        }

        public void Clear()
        {
            DrawPath = new Path();
            CanvasBitmap = Bitmap.CreateBitmap(Width, Height, Bitmap.Config.Argb4444);
            DrawCanvas = new Canvas(CanvasBitmap);
            DrawCanvas.DrawARGB(255, 255, 255, 255);
            Invalidate();
        }

        protected class PointD : Point
        {
            public int dX { get; set; }
            public int dY { get; set; }

            public PointD(int x, int y) : base(x, y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}