namespace RETracer;

static class Extenders
{
    public static int RtfColor(this Color color) => (((color.B << 0x10) | (color.G << 8)) | color.R);
}