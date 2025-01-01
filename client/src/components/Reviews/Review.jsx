import { useState } from "react";
import { getReview, getReviewList } from "../../managers/reviewManager";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import "./Review.css"

export const Review = ({ loggedInUser }) => {
  const [review, setReview] = useState({});
  const [reaction, setReaction] = useState([]);
  const { reviewId } = useParams();

  useEffect(() => {
    getReview(reviewId).then((data) => {
      setReview(data);
    });
  }, [reviewId]);

  return (
    <div className="view-form">
      <header className="header-title">{review?.title}</header>
    <div>{<img src={review?.reactionImage} alt={review.altText} className="photo" />}</div>
    <span className="view-form-static">{review.body}</span>
    </div>
  );
};
