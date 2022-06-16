﻿using FilmBegetter.Domain;

namespace FilmBegetter.WEB.Models.ViewModels;

public class CommentViewModel : BaseViewModel {

    public string AuthorId { get; set; }

    public UserViewModel Author { get; set; }

    public string MovieId { get; set; }

    public MovieViewModel Movie { get; set; }

    public string? ParentCommentId { get; set; }

    public CommentViewModel ParentComment { get; set; }

    public ICollection<CommentViewModel> Answers { get; set; }
    
    public CommentType Type { get; set; }

    public DateTime CreationDate { get; set; }

    public string Body { get; set; }
}