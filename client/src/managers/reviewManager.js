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
