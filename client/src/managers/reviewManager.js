const _apiUrl = "api/Review";

export const getReviewList = () => {
    return fetch(_apiUrl + "/list").then((res) => res.json());
};