﻿//MIT, 2016-present, WinterDev
//----------------------------------- 

using System;
using System.Collections.Generic;

using Typography.Rendering;

namespace PixelFarm.Drawing.Fonts
{
    public enum TextureKind : byte
    {
        StencilLcdEffect, //default
        StencilGreyScale,
        Msdf,
        Bitmap
    }
    public class SimpleFontAtlas
    {
        GlyphImage totalGlyphImage;
        Dictionary<ushort, TextureGlyphMapData> _glyphIndexLocationMap = new Dictionary<ushort, TextureGlyphMapData>();

        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// original font size in point unit
        /// </summary>
        public float OriginalFontSizePts { get; set; }
        public TextureKind TextureKind { get; set; }
        public void AddGlyph(ushort glyphIndex, TextureGlyphMapData glyphData)
        {
            _glyphIndexLocationMap.Add(glyphIndex, glyphData);
        }

        public GlyphImage TotalGlyph
        {
            get { return totalGlyphImage; }
            set { totalGlyphImage = value; }
        }
        public bool TryGetGlyphData(ushort glyphIndex, out TextureGlyphMapData glyphdata)
        {
            if (!_glyphIndexLocationMap.TryGetValue(glyphIndex, out glyphdata))
            {
                glyphdata = null;
                return false;
            }
            return true;
        }

        public string FontFilename { get; set; }

    }

}