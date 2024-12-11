const _apiUrl = "api/Review";

export const getReviewList = () => {
    return fetch(_apiUrl).then((res) => res.json());
};