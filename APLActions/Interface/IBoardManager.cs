using System;
using System.Collections.Generic;
using System.Text;
using APLActions.Models;

namespace APLActions.Interface
{
    public interface IBoardManager
    {
        void SynBoards(string deviceId, List<Board> boards);
        Dictionary<string, List<Board>> GetAllBoards();
        Board Find(string deviceId, int position);
    }
}
