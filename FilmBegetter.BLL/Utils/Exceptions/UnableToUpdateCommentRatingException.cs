using System.Runtime.Serialization;

namespace FilmBegetter.BLL.Utils.Exceptions; 

[Serializable]
public class UnableToUpdateCommentRatingException : InvalidOperationException {
    
    public UnableToUpdateCommentRatingException() {
    }

    protected UnableToUpdateCommentRatingException(SerializationInfo info, StreamingContext context) : base(info, context) {
    }

    public UnableToUpdateCommentRatingException(string? message) : base(message) {
    }

    public UnableToUpdateCommentRatingException(string? message, Exception? innerException) : base(message, innerException) {
    }
}