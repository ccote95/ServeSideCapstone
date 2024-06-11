import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"
import { Button, Card, CardBody, CardImg, CardLink, CardSubtitle, CardTitle } from "reactstrap"
import FlexContainer from "../FlexContainer.jsx"
import { useNavigate } from "react-router-dom"

export default function AllListings()
{
    const [listings, setListings] = useState([])

    const navigate = useNavigate()

    


    useEffect(() => {
        getAll().then(setListings)
    },[])

    useEffect(() => {
        
    },[])

    return (
        <div>
            <Button className="ms-2 mt-2" color="primary" onClick={() => {navigate("create")}}>
                New Listing
            </Button>
            <FlexContainer>
            {listings.map((l) => (
                <Card className="w-25 d-flex flex-column  shadow" key={l.id} style={{maxWidth: "1200px"}}>
                    <CardLink href={`listings/${l.id}`}>
                    {!l.imageBlob ? (
                    <CardImg
                        src={l.productImg}
                    />
                ) : (
                    // <CardImg src={l.imageBlob} />
                    <CardImg src={`data:image/jpeg;base64,${l.imageBlob}`} />
                )}
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
            </FlexContainer>
        </div>
    )
}
