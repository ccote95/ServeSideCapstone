const _apiUrl = "/api/userprofile"

export const getById = (id) => {
    return fetch(`${_apiUrl}?id=${id}`).then(res => res.json());
}