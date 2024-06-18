import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Table } from "reactstrap";
import { getAllByUserId, removeCard } from "../../managers/paymentDetailsManager.js";
import ConfirmDelete from "../PopUps/ConfirmDelete.jsx";

export default function PaymentInfo({loggedInUser})
{
    const [paymentDetails, setPaymentDetails] = useState()
    const [cardToDelete, setCardToDelete] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false)

    const navigate = useNavigate()

    useEffect(() => {
        getAllByUserId(loggedInUser.id).then(setPaymentDetails)
    },[loggedInUser])

    const refresh = () => {
        getAllByUserId(loggedInUser.id).then(setPaymentDetails)
    }
    

    const handleCardRemove = (id) => {
        removeCard(id).then(() => {refresh()})
    }

    const handleConfirmDelete = () => {
        if (cardToDelete) {
            handleCardRemove(cardToDelete);
            setIsModalOpen(false);
            setCardToDelete(null);
        }
    };

    const openConfirmDeleteModal = (id) => {
        setCardToDelete(id);
        setIsModalOpen(true);
    };

    const toggleModal = () => {
        setIsModalOpen(!isModalOpen)
    }

    const formatCardNumber = (number) => {
        return number.replace(/(\d{4})(?=\d)/g, '$1-');
    };

    return(
    <div>
        <div className="d-flex justify-content-between align-items-center mt-2 mb-3 me-2">
            <h2>Payment Details</h2>
            <Button color="success" onClick={() => {navigate("addCard")}}>Add New Card</Button>
        </div>
        <Table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Card Number</th>
                    <th>Card Expiration Date</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {paymentDetails?.map((p, index) => (
                    <tr key={p.id}>
                        <th scope="row">{index +1}</th>
                        <td>{p.userProfile.fullName}</td>
                        <td>{formatCardNumber(p.creditCardNumber)}</td>
                        <td>{p.formattedCreateDateTime}</td>
                        <td><Button color="primary" onClick={() => {navigate(`${p.id}`)}}>Edit</Button></td>
                        <td><Button color="danger" onClick={() => {openConfirmDeleteModal(p.id)}}>Remove</Button></td>
                    </tr>
                ))}
            </tbody>
        </Table>
        <ConfirmDelete
        isOpen={isModalOpen}
        toggle={toggleModal}
        confirmDelete={handleConfirmDelete}
        typeName={"Card"}
        />
        </div>
    )
}