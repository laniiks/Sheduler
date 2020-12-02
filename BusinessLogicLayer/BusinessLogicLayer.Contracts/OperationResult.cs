using System;

namespace BusinessLogicLayer.Contracts
{
    public class OperationResult<TResult>
    {
        public TResult Result { get; set; }
        public bool Success { get; set; }
        public string[] Errors { get; set; }

        public static OperationResult<TResult> Ok(TResult result)
        {
            return new OperationResult<TResult>()
            {
                Success = true,
                Result = result
            };
        }

        public static OperationResult<TResult> Failure(string[] errors)
        {
            return new OperationResult<TResult>()
            {
                Errors = errors
            };
        }

        public string GetErrors()
        {
            return string.Join(Environment.NewLine, Errors);
        }

    }
}
