namespace NotePadLibrary
{
    public interface IViewManager
    {
        double ZoomFactor { get; set; }
        /// <summary>
        /// Reduces the font size of the textbox
        /// </summary>
        /// <param name="zoom"></param>
        /// <returns> returns the updated font size of the text</returns>
        double ZoomIn(double zoom);
        /// <summary>
        /// Increases the font size of the textbox
        /// </summary>
        /// <param name="zoom"></param>
        /// <returns> returns the updated font size of the text</returns>
        double ZoomOut(double zoom);
        /// <summary>
        /// It resets the font of the textbos to the default zoom
        /// </summary>
        /// <returns>returns the value of default zoom</returns>
        double ResetZoom();
    }
}