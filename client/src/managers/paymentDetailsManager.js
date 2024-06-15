const _apiUrl = "/api/paymentDetails"

export const addNewCard = (newCard) => {
    return fetch(_apiUrl,{
        method: "POST",
        headers: {
            "Content-Type":"application/json"
        },
        body: JSON.stringify(newCard)
    })
}