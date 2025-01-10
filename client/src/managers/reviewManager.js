const _apiUrl = "/api/Review";

export const getReviewList = () => {
  return fetch(_apiUrl + "/list").then((res) => res.json());
};

export const getReview = async (reviewId) => {
  return await fetch(_apiUrl + `/${reviewId}`).then((res) => res.json());
};

export const createNewComment = async (comment) => {
  const response = await fetch(_apiUrl + "/comments", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(comment),
  });
  const data = await response.json();
  return data;
};

export const createNewReview = async (review) => {
  const response = await fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(review),
  });
  const data = await response.json();
  return data;
};

export const editExistingReview = async (review, id) => {
  return fetch(_apiUrl + `/${id}`, {
    method: "PUT",
    body: review,
  }).then((res) => res.json());
};

export const deleteReview = async (id) => {
  const response = await fetch(_apiUrl + `/${id}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("Failed to delete review");
  }
};
