import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"
import { Button, Card, CardBody, CardImg, CardLink, CardSubtitle, CardTitle } from "reactstrap"
import PageContainer from "../PageContainer.jsx"

export default function AllListings()
{
    const [listings, setListings] = useState([])


    useEffect(() => {
        getAll().then(setListings)
    },[])

    return(
        <div>
            <Button className="ms-2 mt-2" color="primary">
                New Listing
            </Button>
        <PageContainer>
        {listings.map((l) => (
            <Card className="w-25 d-flex flex-column  shadow" key={l.id} style={{maxWidth: "1200px"}}>
                <CardLink href={`listings/${l.id}`}>
                    <CardImg
                        className="w-50 m-auto rounded mt-1 ms-1"
                        style={{maxHeight: "150px"}}
                        src={l.productImg}
                    />

                </CardLink>
                <CardBody>
                <CardTitle className="m-1 fw-bold">
                    {l.title}
                </CardTitle>
                <CardSubtitle className="m-1">
                    ${l.price}
                </CardSubtitle>
                   
                </CardBody>
            </Card>
        ))}
        </PageContainer>
        </div>
    )
}
// Need to add more data, with prices and temp links,
// need to add price to listing.cs and other DTOs
// need to do styling/