using System;
using Android.Content;
using System.Collections.Generic;
using Android.Widget;

namespace GalleryApp
{
	public class ImageAdapter : BaseAdapter
	{
		Context context;
		Dictionary<int, ImageView> dict;

		public ImageAdapter (Context c)
		{
			context = c;
			dict = new Dictionary<int, ImageView> ();
		}

		public override int Count 
		{
			get { return thumbIds.Length; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId(int position) 
		{
			return 0;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			bool bOut;
			ImageView i;
			bOut = dict.TryGetValue (position, out i);

			if (bOut == false) 
			{
				i = new ImageView(context);
				i.SetImageResource(thumbIds[position]);
				i.LayoutParameters = new Android.Widget.Gallery.LayoutParams(150, 150);
				i.SetScaleType(ImageView.ScaleType.CenterInside);
				dict.Add(position, i);
			}

			return i;
		}

		int[] thumbIds =
		{
			Resource.Drawable.Icon,
			Resource.Drawable.Icon,
			Resource.Drawable.Icon,
			Resource.Drawable.Icon,
			Resource.Drawable.Icon,
			Resource.Drawable.Icon,
			Resource.Drawable.Icon
		};
	}
}

