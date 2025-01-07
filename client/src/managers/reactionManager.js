const _apiUrl = "/api/Reaction";

export const getReactions = () => {
    return fetch(_apiUrl).then((res) => res.json());
};