import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label, Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import { addNewCard, getByCardsId, updateCardDetails } from "../../managers/paymentDetailsManager.js";
import Cleave from "cleave.js/react";

export default function AddCardModal({ isOpen, toggle, loggedInUser, refreshCards, onNewCardAdded }) {
    const [cardNumber, setCardNumber] = useState("");
    const [cardExpiration, setCardExpiration] = useState("");
    const [formErrors, setFormErrors] = useState({});

    useEffect(() => {
        // If there's an id, fetch the card details (handle update case)
    }, []);

    const validateForm = () => {
        const errors = {};
        if (!cardNumber || cardNumber.replace(/\s/g, '').length < 16) {
            errors.cardNumber = "Please enter a valid card number";
        }
        if (!cardExpiration) {
            errors.cardExpiration = "Please enter the card expiration date";
        }
        setFormErrors(errors);
        return Object.keys(errors).length === 0; // Return true if no errors
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (validateForm()) {
            const card = {
                UserProfileId: loggedInUser.id,
                CreditCardNumber: cardNumber.replace(/\s+/g, ''),
                CreditCardExpiration: cardExpiration
                };
                
                addNewCard(card).then((newCard) => {
                onNewCardAdded(newCard)
                toggle();
            });
        }
    };

    return (
        <Modal isOpen={isOpen} toggle={toggle}>
            <ModalHeader toggle={toggle}>Add New Card</ModalHeader>
            <ModalBody>
                <Form onSubmit={handleSubmit}>
                    <FormGroup>
                        <Label className="fw-bold">Card Number</Label>
                        <Cleave
                            value={cardNumber}
                            options={{
                                creditCard: false,
                                blocks: [4, 4, 4, 4],
                                delimiter: '-'
                            }}
                            onChange={(e) => setCardNumber(e.target.rawValue)}
                            className="form-control"
                            placeholder="1234-5678-9012-3456"
                        />
                        {formErrors.cardNumber && (
                            <span className="text-danger">{formErrors.cardNumber}</span>
                        )}
                    </FormGroup>
                    <FormGroup>
                        <Label className="fw-bold">Card Expiration Date</Label>
                        <Input
                            value={cardExpiration}
                            type="date"
                            onChange={(e) => setCardExpiration(e.target.value)}
                        />
                        {formErrors.cardExpiration && (
                            <span className="text-danger">{formErrors.cardExpiration}</span>
                        )}
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" onClick={handleSubmit}>Save</Button>
                <Button color="secondary" onClick={toggle}>Cancel</Button>
            </ModalFooter>
        </Modal>
    );
}
