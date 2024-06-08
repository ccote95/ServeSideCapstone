import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"
import { Card, CardBody, CardImg, CardSubtitle, CardTitle } from "reactstrap"
import PageContainer from "../PageContainer.jsx"

export default function AllListings()
{
    const [listings, setListings] = useState([])


    useEffect(() => {
        getAll().then(setListings)
    },[])

    return(
        <PageContainer>
        {listings.map((l) => (
            <Card className="w-25 d-flex flex-column  shadow" key={l.id} style={{maxWidth: "1200px"}}>
                <CardImg
                className="w-50 m-auto rounded mt-1"
                src={l.productImg}/>
                <CardBody>
                <CardTitle className="m-1 fw-bold">
                    {l.title}
                </CardTitle>
                <CardSubtitle className="m-1">
                    ${l.price}
                </CardSubtitle>
                    {l.content}
                </CardBody>
            </Card>
        ))}
        </PageContainer>
    )
}
// Need to add more data, with prices and temp links,
// need to add price to listing.cs and other DTOs
// need to do styling/