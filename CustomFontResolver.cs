using PdfSharpCore.Fonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class CustomFontResolver : IFontResolver
{
    private static readonly Dictionary<string, byte[]> FontCache = new();

    public string DefaultFontName => "Arial";

    public byte[] GetFont(string faceName)
    {
        if (FontCache.TryGetValue(faceName, out var data))
            return data;

        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = $"Notes.Fonts.arial.ttf";

        using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
        {
            if (stream == null)
                throw new Exception($"Не удалось найти встроенный шрифт: {resourcePath}");

            using (MemoryStream ms = new())
            {
                stream.CopyTo(ms);
                data = ms.ToArray();
                FontCache[faceName] = data;
                return data;
            }
        }
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        string faceName = "Arial";

        if (isBold && isItalic)
            faceName += "#bi";
        else if (isBold)
            faceName += "#b";
        else if (isItalic)
            faceName += "#i";
        else
            faceName += "#";

        return new FontResolverInfo(faceName);
    }
}
