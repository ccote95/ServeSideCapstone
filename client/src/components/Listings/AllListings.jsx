import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"
import { Card, CardBody, CardImg, CardSubtitle, CardTitle } from "reactstrap"

export default function AllListings()
{
    const [listings, setListings] = useState([])


    useEffect(() => {
        getAll().then(setListings)
    },[])

    return(
        <>
        {listings.map((l) => (
            <Card className="w-50 m-auto"  style={{maxWidth: "1200px"}}>
                <CardImg
                className="w-25 rounded"
                src={l.productImg}/>
                <CardTitle>
                    {l.title}
                </CardTitle>
                <CardSubtitle>
                    {l.price}
                </CardSubtitle>
                <CardBody>
                    {l.content}
                </CardBody>
            </Card>
        ))}
        </>
    )
}
// Need to add more data, with prices and temp links,
// need to add price to listing.cs and other DTOs
// need to do styling/