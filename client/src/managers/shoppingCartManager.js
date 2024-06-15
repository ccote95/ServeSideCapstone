const _apiUrl = "/api/shoppingCart"

export const addToCart = (id, userId) => {
    return fetch(`${_apiUrl}?id=${id}&userId=${userId}`, {
        method: "POST"
    })
}

export const getAllCartsById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then(res => res.json())
}

export const removeItemFromCart = (id,userId) => {
    return fetch(`${_apiUrl}/${id}?userProfileId=${userId}`,{
        method: "DELETE"
    })
}