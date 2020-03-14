namespace Base
{
	public partial struct Color
	{
		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 255, 255, 0).
		/// </summary>
		public static Color Transparent => new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (240, 248, 255, 255).
		/// </summary>
		public static Color AliceBlue => new Color(240, 248, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (250, 235, 215, 255).
		/// </summary>
		public static Color AntiqueWhite => new Color(250, 235, 215, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 255, 255, 255).
		/// </summary>
		public static Color Aqua => new Color(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (127, 255, 212, 255).
		/// </summary>
		public static Color Aquamarine => new Color(127, byte.MaxValue, 212, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (240, 255, 255, 255).
		/// </summary>
		public static Color Azure => new Color(240, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (245, 245, 220, 255).
		/// </summary>
		public static Color Beige => new Color(245, 245, 220, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 228, 196, 255).
		/// </summary>
		public static Color Bisque => new Color(byte.MaxValue, 228, 196, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 0, 0, 255).
		/// </summary>
		public static Color Black => new Color(0, 0, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 235, 205, 255).
		/// </summary>
		public static Color BlanchedAlmond => new Color(byte.MaxValue, 235, 205, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 0, 255, 255).
		/// </summary>
		public static Color Blue => new Color(0, 0, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (138, 43, 226, 255).
		/// </summary>
		public static Color BlueViolet => new Color(138, 43, 226, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (165, 42, 42, 255).
		/// </summary>
		public static Color Brown => new Color(165, 42, 42, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (222, 184, 135, 255).
		/// </summary>
		public static Color BurlyWood => new Color(222, 184, 135, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (95, 158, 160, 255).
		/// </summary>
		public static Color CadetBlue => new Color(95, 158, 160, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (127, 255, 0, 255).
		/// </summary>
		public static Color Chartreuse => new Color(127, byte.MaxValue, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (210, 105, 30, 255).
		/// </summary>
		public static Color Chocolate => new Color(210, 105, 30, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 127, 80, 255).
		/// </summary>
		public static Color Coral => new Color(byte.MaxValue, 127, 80, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (100, 149, 237, 255).
		/// </summary>
		public static Color CornflowerBlue => new Color(100, 149, 237, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 248, 220, 255).
		/// </summary>
		public static Color Cornsilk => new Color(byte.MaxValue, 248, 220, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (220, 20, 60, 255).
		/// </summary>
		public static Color Crimson => new Color(220, 20, 60, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 255, 255, 255).
		/// </summary>
		public static Color Cyan => new Color(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 0, 139, 255).
		/// </summary>
		public static Color DarkBlue => new Color(0, 0, 139, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 139, 139, 255).
		/// </summary>
		public static Color DarkCyan => new Color(0, 139, 139, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (184, 134, 11, 255).
		/// </summary>
		public static Color DarkGoldenrod => new Color(184, 134, 11, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (169, 169, 169, 255).
		/// </summary>
		public static Color DarkGray => new Color(169, 169, 169, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 100, 0, 255).
		/// </summary>
		public static Color DarkGreen => new Color(0, 100, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (189, 183, 107, 255).
		/// </summary>
		public static Color DarkKhaki => new Color(189, 183, 107, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (139, 0, 139, 255).
		/// </summary>
		public static Color DarkMagenta => new Color(139, 0, 139, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (85, 107, 47, 255).
		/// </summary>
		public static Color DarkOliveGreen => new Color(85, 107, 47, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 140, 0, 255).
		/// </summary>
		public static Color DarkOrange => new Color(byte.MaxValue, 140, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (153, 50, 204, 255).
		/// </summary>
		public static Color DarkOrchid => new Color(153, 50, 204, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (139, 0, 0, 255).
		/// </summary>
		public static Color DarkRed => new Color(139, 0, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (233, 150, 122, 255).
		/// </summary>
		public static Color DarkSalmon => new Color(233, 150, 122, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (143, 188, 139, 255).
		/// </summary>
		public static Color DarkSeaGreen => new Color(143, 188, 139, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (72, 61, 139, 255).
		/// </summary>
		public static Color DarkSlateBlue => new Color(72, 61, 139, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (47, 79, 79, 255).
		/// </summary>
		public static Color DarkSlateGray => new Color(47, 79, 79, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 206, 209, 255).
		/// </summary>
		public static Color DarkTurquoise => new Color(0, 206, 209, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (148, 0, 211, 255).
		/// </summary>
		public static Color DarkViolet => new Color(148, 0, 211, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 20, 147, 255).
		/// </summary>
		public static Color DeepPink => new Color(byte.MaxValue, 20, 147, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 191, 255, 255).
		/// </summary>
		public static Color DeepSkyBlue => new Color(0, 191, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (105, 105, 105, 255).
		/// </summary>
		public static Color DimGray => new Color(105, 105, 105, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (30, 144, 255, 255).
		/// </summary>
		public static Color DodgerBlue => new Color(30, 144, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (178, 34, 34, 255).
		/// </summary>
		public static Color Firebrick => new Color(178, 34, 34, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 250, 240, 255).
		/// </summary>
		public static Color FloralWhite => new Color(byte.MaxValue, 250, 240, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (34, 139, 34, 255).
		/// </summary>
		public static Color ForestGreen => new Color(34, 139, 34, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 0, 255, 255).
		/// </summary>
		public static Color Fuchsia => new Color(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (220, 220, 220, 255).
		/// </summary>
		public static Color Gainsboro => new Color(220, 220, 220, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (248, 248, 255, 255).
		/// </summary>
		public static Color GhostWhite => new Color(248, 248, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 215, 0, 255).
		/// </summary>
		public static Color Gold => new Color(byte.MaxValue, 215, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (218, 165, 32, 255).
		/// </summary>
		public static Color Goldenrod => new Color(218, 165, 32, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (128, 128, 128, 255).
		/// </summary>
		public static Color Gray => new Color(128, 128, 128, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 128, 0, 255).
		/// </summary>
		public static Color Green => new Color(0, 128, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (173, 255, 47, 255).
		/// </summary>
		public static Color GreenYellow => new Color(173, byte.MaxValue, 47, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (240, 255, 240, 255).
		/// </summary>
		public static Color Honeydew => new Color(240, byte.MaxValue, 240, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 105, 180, 255).
		/// </summary>
		public static Color HotPink => new Color(byte.MaxValue, 105, 180, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (205, 92, 92, 255).
		/// </summary>
		public static Color IndianRed => new Color(205, 92, 92, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (75, 0, 130, 255).
		/// </summary>
		public static Color Indigo => new Color(75, 0, 130, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 255, 240, 255).
		/// </summary>
		public static Color Ivory => new Color(byte.MaxValue, byte.MaxValue, 240, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (240, 230, 140, 255).
		/// </summary>
		public static Color Khaki => new Color(240, 230, 140, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (230, 230, 250, 255).
		/// </summary>
		public static Color Lavender => new Color(230, 230, 250, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 240, 245, 255).
		/// </summary>
		public static Color LavenderBlush => new Color(byte.MaxValue, 240, 245, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (124, 252, 0, 255).
		/// </summary>
		public static Color LawnGreen => new Color(124, 252, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 250, 205, 255).
		/// </summary>
		public static Color LemonChiffon => new Color(byte.MaxValue, 250, 205, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (173, 216, 230, 255).
		/// </summary>
		public static Color LightBlue => new Color(173, 216, 230, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (240, 128, 128, 255).
		/// </summary>
		public static Color LightCoral => new Color(240, 128, 128, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (224, 255, 255, 255).
		/// </summary>
		public static Color LightCyan => new Color(224, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (250, 250, 210, 255).
		/// </summary>
		public static Color LightGoldenrodYellow => new Color(250, 250, 210, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (144, 238, 144, 255).
		/// </summary>
		public static Color LightGreen => new Color(144, 238, 144, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (211, 211, 211, 255).
		/// </summary>
		public static Color LightGray => new Color(211, 211, 211, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 182, 193, 255).
		/// </summary>
		public static Color LightPink => new Color(byte.MaxValue, 182, 193, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 160, 122, 255).
		/// </summary>
		public static Color LightSalmon => new Color(byte.MaxValue, 160, 122, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (32, 178, 170, 255).
		/// </summary>
		public static Color LightSeaGreen => new Color(32, 178, 170, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (135, 206, 250, 255).
		/// </summary>
		public static Color LightSkyBlue => new Color(135, 206, 250, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (119, 136, 153, 255).
		/// </summary>
		public static Color LightSlateGray => new Color(119, 136, 153, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (176, 196, 222, 255).
		/// </summary>
		public static Color LightSteelBlue => new Color(176, 196, 222, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 255, 224, 255).
		/// </summary>
		public static Color LightYellow => new Color(byte.MaxValue, byte.MaxValue, 224, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 255, 0, 255).
		/// </summary>
		public static Color Lime => new Color(0, byte.MaxValue, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (50, 205, 50, 255).
		/// </summary>
		public static Color LimeGreen => new Color(50, 205, 50, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (250, 240, 230, 255).
		/// </summary>
		public static Color Linen => new Color(250, 240, 230, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 0, 255, 255).
		/// </summary>
		public static Color Magenta => new Color(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (128, 0, 0, 255).
		/// </summary>
		public static Color Maroon => new Color(128, 0, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (102, 205, 170, 255).
		/// </summary>
		public static Color MediumAquamarine => new Color(102, 205, 170, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 0, 205, 255).
		/// </summary>
		public static Color MediumBlue => new Color(0, 0, 205, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (186, 85, 211, 255).
		/// </summary>
		public static Color MediumOrchid => new Color(186, 85, 211, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (147, 112, 219, 255).
		/// </summary>
		public static Color MediumPurple => new Color(147, 112, 219, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (60, 179, 113, 255).
		/// </summary>
		public static Color MediumSeaGreen => new Color(60, 179, 113, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (123, 104, 238, 255).
		/// </summary>
		public static Color MediumSlateBlue => new Color(123, 104, 238, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 250, 154, 255).
		/// </summary>
		public static Color MediumSpringGreen => new Color(0, 250, 154, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (72, 209, 204, 255).
		/// </summary>
		public static Color MediumTurquoise => new Color(72, 209, 204, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (199, 21, 133, 255).
		/// </summary>
		public static Color MediumVioletRed => new Color(199, 21, 133, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (25, 25, 112, 255).
		/// </summary>
		public static Color MidnightBlue => new Color(25, 25, 112, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (245, 255, 250, 255).
		/// </summary>
		public static Color MintCream => new Color(245, byte.MaxValue, 250, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 228, 225, 255).
		/// </summary>
		public static Color MistyRose => new Color(byte.MaxValue, 228, 225, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 228, 181, 255).
		/// </summary>
		public static Color Moccasin => new Color(byte.MaxValue, 228, 181, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 222, 173, 255).
		/// </summary>
		public static Color NavajoWhite => new Color(byte.MaxValue, 222, 173, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 0, 128, 255).
		/// </summary>
		public static Color Navy => new Color(0, 0, 128, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (253, 245, 230, 255).
		/// </summary>
		public static Color OldLace => new Color(253, 245, 230, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (128, 128, 0, 255).
		/// </summary>
		public static Color Olive => new Color(128, 128, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (107, 142, 35, 255).
		/// </summary>
		public static Color OliveDrab => new Color(107, 142, 35, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 165, 0, 255).
		/// </summary>
		public static Color Orange => new Color(byte.MaxValue, 165, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 69, 0, 255).
		/// </summary>
		public static Color OrangeRed => new Color(byte.MaxValue, 69, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (218, 112, 214, 255).
		/// </summary>
		public static Color Orchid => new Color(218, 112, 214, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (238, 232, 170, 255).
		/// </summary>
		public static Color PaleGoldenrod => new Color(238, 232, 170, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (152, 251, 152, 255).
		/// </summary>
		public static Color PaleGreen => new Color(152, 251, 152, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (175, 238, 238, 255).
		/// </summary>
		public static Color PaleTurquoise => new Color(175, 238, 238, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (219, 112, 147, 255).
		/// </summary>
		public static Color PaleVioletRed => new Color(219, 112, 147, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 239, 213, 255).
		/// </summary>
		public static Color PapayaWhip => new Color(byte.MaxValue, 239, 213, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 218, 185, 255).
		/// </summary>
		public static Color PeachPuff => new Color(byte.MaxValue, 218, 185, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (205, 133, 63, 255).
		/// </summary>
		public static Color Peru => new Color(205, 133, 63, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 192, 203, 255).
		/// </summary>
		public static Color Pink => new Color(byte.MaxValue, 192, 203, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (221, 160, 221, 255).
		/// </summary>
		public static Color Plum => new Color(221, 160, 221, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (176, 224, 230, 255).
		/// </summary>
		public static Color PowderBlue => new Color(176, 224, 230, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (128, 0, 128, 255).
		/// </summary>
		public static Color Purple => new Color(128, 0, 128, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 0, 0, 255).
		/// </summary>
		public static Color Red => new Color(byte.MaxValue, 0, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (188, 143, 143, 255).
		/// </summary>
		public static Color RosyBrown => new Color(188, 143, 143, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (65, 105, 225, 255).
		/// </summary>
		public static Color RoyalBlue => new Color(65, 105, 225, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (139, 69, 19, 255).
		/// </summary>
		public static Color SaddleBrown => new Color(139, 69, 19, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (250, 128, 114, 255).
		/// </summary>
		public static Color Salmon => new Color(250, 128, 114, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (244, 164, 96, 255).
		/// </summary>
		public static Color SandyBrown => new Color(244, 164, 96, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (46, 139, 87, 255).
		/// </summary>
		public static Color SeaGreen => new Color(46, 139, 87, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 245, 238, 255).
		/// </summary>
		public static Color SeaShell => new Color(byte.MaxValue, 245, 238, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (160, 82, 45, 255).
		/// </summary>
		public static Color Sienna => new Color(160, 82, 45, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (192, 192, 192, 255).
		/// </summary>
		public static Color Silver => new Color(192, 192, 192, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (135, 206, 235, 255).
		/// </summary>
		public static Color SkyBlue => new Color(135, 206, 235, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (106, 90, 205, 255).
		/// </summary>
		public static Color SlateBlue => new Color(106, 90, 205, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (112, 128, 144, 255).
		/// </summary>
		public static Color SlateGray => new Color(112, 128, 144, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 250, 250, 255).
		/// </summary>
		public static Color Snow => new Color(byte.MaxValue, 250, 250, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 255, 127, 255).
		/// </summary>
		public static Color SpringGreen => new Color(0, byte.MaxValue, 127, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (70, 130, 180, 255).
		/// </summary>
		public static Color SteelBlue => new Color(70, 130, 180, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (210, 180, 140, 255).
		/// </summary>
		public static Color Tan => new Color(210, 180, 140, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (0, 128, 128, 255).
		/// </summary>
		public static Color Teal => new Color(0, 128, 128, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (216, 191, 216, 255).
		/// </summary>
		public static Color Thistle => new Color(216, 191, 216, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 99, 71, 255).
		/// </summary>
		public static Color Tomato => new Color(byte.MaxValue, 99, 71, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (64, 224, 208, 255).
		/// </summary>
		public static Color Turquoise => new Color(64, 224, 208, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (238, 130, 238, 255).
		/// </summary>
		public static Color Violet => new Color(238, 130, 238, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (245, 222, 179, 255).
		/// </summary>
		public static Color Wheat => new Color(245, 222, 179, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 255, 255, 255).
		/// </summary>
		public static Color White => new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (245, 245, 245, 255).
		/// </summary>
		public static Color WhiteSmoke => new Color(245, 245, 245, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (255, 255, 0, 255).
		/// </summary>
		public static Color Yellow => new Color(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);

		/// <summary>
		///     Gets the system color with (R, G, B, A) = (154, 205, 50, 255).
		/// </summary>
		public static Color YellowGreen => new Color(154, 205, 50, byte.MaxValue);
	}
}