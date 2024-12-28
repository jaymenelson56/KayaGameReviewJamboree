import { useState } from "react";
import { getReview, getReviewList } from "../../managers/reviewManager";
import { useEffect } from "react";
import { useParams } from "react-router-dom";

export const Review = ({ loggedInUser }) => {
  const [review, setReview] = useState({});
  const [reaction, setReaction] = useState([]);
  const { reviewId } = useParams();

  useEffect(() => {
    getReview(reviewId).then((data) => {
        const reviewObj = data[0]
        setReview(reviewObj)
    });
  });

  return(
  <div className="view-form">
    <div className="view-form-static">here</div>
  </div>)
};
