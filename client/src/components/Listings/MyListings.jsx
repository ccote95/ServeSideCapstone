import { useEffect, useState } from "react"
import { getAllListingsById } from "../../managers/listingManger.js"
import PageContainer from "../PageContainer.jsx"
import FlexContainer from "../FlexContainer.jsx"
import { Button, Card, CardBody, CardImg, CardLink, CardSubtitle, CardTitle } from "reactstrap"
import { useNavigate } from "react-router-dom"

export default function MyListings({loggedInUser})
{
    const [myListings, setMyListings] = useState([])

    const navigate = useNavigate()

    useEffect(() => {
        getAllListingsById(loggedInUser.id).then(setMyListings)
    },[])
    return(
        <>
        <Button 
            className="ms-2 mt-2" 
            color="primary" 
            onClick={() => {navigate("/listings/create")}}
        >
            New Listing
        </Button>
        <h1 className="d-flex justify-content-center">My Listings</h1>
        
        <FlexContainer>
        {myListings?.map((l) => (
            <Card className="w-25 d-flex flex-column  shadow" key={l.id} style={{maxWidth: "1200px",  height: "400px"}}>
                    <CardLink href={`/listings/${l.id}`}>
                    {!l.imageBlob ? (
                        <CardImg
                        className="mt-1"
                        src={l.productImg}
                        style={{ height: "200px", objectFit: "contain" }}
                        />
                        ) : (
                            <CardImg 
                            src={`data:image/jpeg;base64,${l.imageBlob}`}
                            style={{ height: "200px", objectFit: "contain" }} 
                            className="mt-1"
                            />
                            )}
                    </CardLink>
                    <CardBody>
                        <CardTitle className="m-1 fs-1 fw-bold">
                            {l.title}
                        </CardTitle>
                    <CardSubtitle className="m-1 fs-2">
                        ${l.price}
                    </CardSubtitle>
                    
                    </CardBody>
                </Card>
            ))}
        </FlexContainer>
        </>
    )
}