const _apiUrl = "/api/shoppingCart"

export const addToCart = (id) => {
    return fetch(`${_apiUrl}?id=${id}`, {
        method: "POST"
    })
}