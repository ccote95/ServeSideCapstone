const _api = "api/listing"

export const getAll = () => {
return fetch(_api).then(res => res.json())
}