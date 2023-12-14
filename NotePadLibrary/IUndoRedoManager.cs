namespace NotePadLibrary
{
    public interface IUndoRedoManager
    {
        /// <summary>
        /// Performs Undo on Textbox
        /// </summary>
        /// <returns> returns previous state of the textbox</returns>
        TextBoxState Undo();
        /// <summary>
        /// Performs Redo on Textbox
        /// </summary>
        /// <returns>returns the previus state</returns>
        TextBoxState Redo();
    }
}
