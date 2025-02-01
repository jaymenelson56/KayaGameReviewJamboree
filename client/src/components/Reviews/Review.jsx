import { useState } from "react";
import { createNewComment, getReview } from "../../managers/reviewManager";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import "./Review.css";

export const Review = ({ loggedInUser }) => {
  const [review, setReview] = useState({});
  const [reaction, setReaction] = useState([]);
  const [newComment, setNewComment] = useState({
    userProfileId: 0,
    reviewId: 0,
    body: "",
  });
  const { reviewId } = useParams();

  useEffect(() => {
    getReview(reviewId).then((data) => {
      setReview(data);
    });
  }, [reviewId]);

  const handleCommentSave = (event) => {
    event.preventDefault();
    console.log("LoggedInUser:", loggedInUser);
    if (newComment.body) {
      const newPost = {
        userProfileId: loggedInUser.id,
        reviewId: review.id,
        body: newComment.body,
      };
      createNewComment(newPost).then(() => window.location.reload());
    } else {
      window.alert("Please fill out comment");
    }
  };

  return (
    <div className="view-form">
      <header className="header-title">{review?.title}</header>
      <div>
        {
          <img
            src={review?.reactionImage}
            alt={review.altText}
            className="photo"
          />
        }
      </div>
      <span className="view-form-static">{review.body}</span>
      {/* Delete and Edit Button needed here for review author */}
      <div>
        <h2>Comments</h2>
        {review.comments && review.comments.length > 0 ? (
          review.comments.map((comment) => (
            <span key = {comment.id}>
              {comment.userName}: {comment.body}
              <br />
            </span>
          ))
        ) : (
          <p>No comments yet.</p>
        )}
      </div>
      <div>
        <h3>Type Comment Here</h3>
        <label htmlFor="comment">{loggedInUser?.userName}: </label>
        <input
          type="text"
          id="comment"
          placeholder="Comment Here"
          name="comment"
          onChange={(event) => {
            const newPostCopy = { ...newComment };
            newPostCopy.body = event.target.value;
            setNewComment(newPostCopy);
          }}
        />
        <button className="post-btn" onClick={handleCommentSave}>
          Post
        </button>
      </div>
    </div>
  );
};
