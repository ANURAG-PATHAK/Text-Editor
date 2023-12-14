using System.Collections.Generic;
using System;
using NotePadLibrary.Properties;

namespace NotePadLibrary
{
    public class UndoRedoManager : IUndoRedoManager
    {
        private int _stackLimit = 100;
        public int StackLimit
        {
            get { return _stackLimit; }
            set { _stackLimit = value; }
        }
        private Stack<TextBoxState> _undoStack;
        private Stack<TextBoxState> _redoStack;
        public UndoRedoManager()
        {
            _undoStack = new Stack<TextBoxState>();
            _redoStack = new Stack<TextBoxState>();
        }
        public TextBoxState Undo()
        {
            if (_undoStack.Count > 0)
            {
                if (_redoStack.Count < StackLimit)
                {
                    _redoStack.Push(_undoStack.Pop());
                    return _undoStack.Peek();
                }
                else
                {
                    Stack<TextBoxState> newStack = new Stack<TextBoxState>();
                    while (_redoStack.Count > 0)
                    {
                        newStack.Push(_redoStack.Pop());
                    }
                    newStack.Pop();
                    while (newStack.Count > 0)
                    {
                        _redoStack.Push(newStack.Pop());
                    }
                    _redoStack.Push(_undoStack.Pop());
                    newStack.Clear();
                    return _undoStack.Peek();
                }
            }
            else
            {
                throw new Exception(Resources.StackUnderflow);
            }
        }
        public TextBoxState Redo()
        {
            if (_redoStack.Count > 0)
            {
                if (_undoStack.Count < StackLimit)
                {
                    _undoStack.Push(_redoStack.Peek());
                    return _redoStack.Pop();
                }
                else
                {
                    Stack<TextBoxState> newStack = new Stack<TextBoxState>();
                    while (_undoStack.Count > 0)
                    {
                        newStack.Push(_undoStack.Pop());
                    }
                    newStack.Pop();
                    while (newStack.Count > 0)
                    {
                        _undoStack.Push(newStack.Pop());
                    }
                    _undoStack.Push(_redoStack.Peek());
                    newStack.Clear();
                    return _redoStack.Pop();
                }
            }
            else
            {
                throw new Exception(Resources.StackUnderflow);
            }
        }
        public void Push(TextBoxState state)
        {
            if (_undoStack.Count < StackLimit)
            {
                if (_undoStack.Count == 0)
                {
                    TextBoxState emptyState = new TextBoxState(string.Empty, state.Font);
                    _undoStack.Push(emptyState);
                }
                _undoStack.Push(state);
            }
            else
            {
                Stack<TextBoxState> newStack = new Stack<TextBoxState>();
                while (_undoStack.Count > 0)
                {
                    newStack.Push(_undoStack.Pop());
                }
                newStack.Pop();
                while (newStack.Count > 0)
                {
                    _undoStack.Push(newStack.Pop());
                }
                _undoStack.Push(state);
                newStack.Clear();
            }
        }
    }
}