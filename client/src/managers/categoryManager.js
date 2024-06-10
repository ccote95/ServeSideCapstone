const _api = "/api/category"

export const getAll = () => {
    return fetch(_api).then(res => res.json())
}