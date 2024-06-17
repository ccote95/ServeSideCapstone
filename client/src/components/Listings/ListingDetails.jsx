import { useNavigate, useParams } from "react-router-dom";
import PageContainer from "../FlexContainer.jsx";
import { Badge, Button, Card, CardBody, CardImg, CardImgOverlay } from "reactstrap";
import { useEffect, useState } from "react";
import { deleteListing, getListingById } from "../../managers/listingManger.js";
import { addToCart } from "../../managers/shoppingCartManager.js";
import CustomToast from "../PopUps/AddingToCartToast.jsx";
import ConfirmDelete from "../PopUps/ConfirmDelete.jsx";

export default function ListingDetails({ loggedInUser }) {
    const [toastOpen, setToastOpen] = useState(false);
    const [toastMessage, setToastMessage] = useState('');
    const [listing, setListing] = useState();
    const [isModalOpen, setIsModalOpen] = useState(false)

    const navigate = useNavigate();

    const { id } = useParams();

    useEffect(() => {
        getListingById(parseInt(id)).then(setListing);
    }, []);

    const handleDelete = () => {
        deleteListing(parseInt(id)).then(() => { navigate("/listings"); });
    };

    const toggleToast = () => setToastOpen(!toastOpen);

    const handleAddToCart = async () => {
        try {
            await addToCart(listing.id, loggedInUser.id);
            setToastMessage("Item added to cart!");
            setToastOpen(true);
        } catch (error) {
            setToastMessage("Failed to add item to cart.");
            setToastOpen(true);
        }
        // Automatically close the toast after 3 seconds
        setTimeout(() => {
            setToastOpen(false);
        }, 3000);
    };

    const toggleModal = () => {
        setIsModalOpen(!isModalOpen)
    }

    return (
        <PageContainer>
            <Card className="shadow" style={{ width: "60%" }}>
                {!listing?.imageBlob ? (
                    <CardImg
                        src={listing?.productImg}
                        style={{ height: "400px", objectFit: "scale-down" }}
                    />
                ) : (
                    <CardImg src={`data:image/jpeg;base64,${listing?.imageBlob}`} style={{ height: "400px", objectFit: "scale-down" }} />
                )}
                <CardImgOverlay className="pe-none">
                    <Badge className="fs-4 " pill>
                        {listing?.title}
                    </Badge>
                    <Badge style={{ float: "right" }}>
                        {listing?.formattedDate}
                    </Badge>
                    <div className="pe-auto fs-3">
                        <Badge pill>
                            {listing?.userProfile.fullName}
                        </Badge>
                    </div>
                    {listing?.categories.map((c) => (
                        <div className="w-25 pe-auto fs-5" key={c.id}>
                            <Badge className="pe-none" pill>
                                {c.name}
                            </Badge>
                        </div>
                    ))}
                    <div className="pe-auto">
                        <Badge pill>
                            ${listing?.price}
                        </Badge>
                    </div>
                </CardImgOverlay>
                <CardBody className="m-auto">
                    {listing?.content}
                </CardBody>
                <div>
                    <Button
                        className="me-2"
                        style={{ width: "11%", float: "right" }}
                        onClick={handleAddToCart}
                    >
                        Add To Cart
                    </Button>
                </div>
                <CustomToast isOpen={toastOpen} toggle={toggleToast} message={toastMessage} />
                <div className="d-flex flex-row flex-wrap mt-3 w-100 gap-2 justify-content-md-end ">
                    {listing?.userProfile.id === loggedInUser.id && (
                        <>
                            <Button className="me-2 mb-1" onClick={toggleModal}>
                                DELETE
                            </Button>
                            <Button className="me-2 mb-1" onClick={() => { navigate("edit"); }}>
                                Edit
                            </Button>
                        </>
                    )}
                </div>
            </Card>
            <ConfirmDelete
                isOpen = {isModalOpen}
                toggle = {toggleModal}
                confirmDelete={handleDelete}
                typeName={"listing"}
            />
        </PageContainer>
    );
}


//getListingById returns invalid json for some reason. need to ask someone about that