const _api = "/api/listing"

export const getAll = () => {
return fetch(_api).then(res => res.json())
}

export const getListingById = (id) => {
    return fetch(`${_api}/${id}`).then(res => res.json())
}