using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipStateTracker.Data.ResponseDto
{
    public class ErrorResponseDto
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
