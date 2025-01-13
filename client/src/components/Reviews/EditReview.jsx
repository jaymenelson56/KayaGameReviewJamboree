import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getReactions } from "../../managers/reactionManager";
import { getReview, editExistingReview } from "../../managers/reviewManager";
import "./Review.css";

export const EditReview = ({ loggedInUser }) => {
  const [review, setReview] = useState({
    title: "",
    body: "",
    reactionId: 0,
  });
  const [reactions, setReactions] = useState([]);
  const [selectedImage, setSelectedImage] = useState(null);
  const { reviewId } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getReview(reviewId).then((data) => {
      setReview(data);
    });
  }, [reviewId]);

  useEffect(() => {
    getReactions().then((reactionsArray) => setReactions(reactionsArray));
  }, []);

  useEffect(() => {
    const selectedReaction = reactions.find(
      (reaction) => reaction.id === review.reactionId
    );
    setSelectedImage(selectedReaction || null);
  }, [review.reactionId, reactions]);

  const handleSave = (event) => {
    event.preventDefault();

    if (!review.title || !review.body || !review.reactionId) {
      alert("All fields are required.");
      return;
    }

    const editedReview = {
      title: review.title,
      body: review.body,
      reactionId: review.reactionId,
    };

    editExistingReview(editedReview, reviewId).then(() => {
      navigate("/reviews");
    });
  };

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setReview((prevReview) => ({
      ...prevReview,
      [name]: name === "reactionId" ? parseInt(value) : value,
    }));
  };

  return (
    <form className="view-form">
      <fieldset>
        <div className="form-group">
          <label htmlFor="title">Title:</label>
          <input
            type="text"
            id="title"
            name="title"
            value={review.title}
            onChange={handleInputChange}
            className="form-control"
          />
        </div>
      </fieldset>

      <fieldset>
        <div className="form-group">
          <label htmlFor="reactionId">Reaction:</label>
          <select
            id="reactionId"
            name="reactionId"
            value={review.reactionId}
            onChange={handleInputChange}
            className="form-control"
          >
            <option value="" hidden>
              Select Reaction...
            </option>
            {reactions.map((reaction) => (
              <option key={reaction.id} value={reaction.id}>
                {reaction.description}
              </option>
            ))}
          </select>
          {selectedImage && (
            <div className="reaction-image">
              <img
                src={selectedImage.image}
                alt={selectedImage.altText}
                className="photo"
              />
            </div>
          )}
        </div>
      </fieldset>

      <fieldset>
        <div className="form-group">
          <label htmlFor="body">Review:</label>
          <textarea
            id="body"
            name="body"
            value={review.body}
            onChange={handleInputChange}
            rows={5}
            cols={30}
            className="form-control"
          />
        </div>
      </fieldset>

      <fieldset className="form-actions">
        <button type="button" onClick={handleSave} className="btn btn-primary">
          Save
        </button>
        <button
          type="button"
          onClick={() => navigate("/reviews")}
          className="btn btn-secondary"
        >
          Cancel
        </button>
      </fieldset>
    </form>
  );
};
