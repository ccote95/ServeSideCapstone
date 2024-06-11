const _api = "/api/category"

export const getAllCategories = () => {
    return fetch(_api).then(res => res.json())
}