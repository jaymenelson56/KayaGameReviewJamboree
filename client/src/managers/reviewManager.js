const _apiUrl = "/api/Review";

export const getReviewList = () => {
    return fetch(_apiUrl + "/list").then((res) => res.json());
};

export const getReview = async (reviewId) => {
    return await fetch(_apiUrl + `/${reviewId}`).then((res) => res.json());
}