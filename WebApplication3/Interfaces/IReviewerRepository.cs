using WebApplication3.Models;

namespace WebApplication3.Interfaces;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int reviewerId);
    ICollection<Review> GetReviewsByReviewer(int reviewerId);
    bool ReviewerExists(int reviewerId);
    bool CreateReviewer(Reviewer reviewer);
    bool UpdateReviewer(Reviewer reviewer);
    bool Save();
}