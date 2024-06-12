import { Button, Col,Form, FormGroup, Input, Label, Row } from "reactstrap";
import PageContainer from "../PageContainer.jsx";
import { useEffect, useState } from "react";
import {  getAllCategories } from "../../managers/categoryManager.js";
import { createListing, getListingById, updateListing } from "../../managers/listingManger.js";
import { useNavigate, useParams } from "react-router-dom";

export default function ListingForm({loggedInUser})
{
    const [categories, setCategories] = useState()
    const [title, setTitle] = useState("")
    const [content, setContent] = useState("")
    const [price, setPrice] = useState(0)
    const [image, setImage] = useState()
    const [imagePreview, setImagePreview] = useState()
    const [chosenCategories, setChosenCategories] = useState([])
    const [originalImage, setOriginalImage] = useState()

    const navigate = useNavigate()

    const {id} = useParams()

    useEffect(() => {
        getAllCategories().then(setCategories)

        if(id){
            getListingById(id).then(listing => {
                setTitle(listing.title)
                setContent(listing.content)
                setPrice(listing.price)
                setImagePreview(`data:image/jpeg;base64,${listing.imageBlob}`)
                setChosenCategories(listing.categories.map(c => c.id))
               
                setOriginalImage(listing.imageBlob)
                console.log(typeof(listing.imageBlob))
                console.log(originalImage)

                var image = new File([listing.imageBlob], "existing-image.jpg", { type: "image/jpeg" })
            })
        }
    },[])

    const handleCheckBoxChange = (categoryId) => {
        const selectedCategories = [...chosenCategories];
        const index = selectedCategories.indexOf(categoryId)
        if(index === -1)
            {
                selectedCategories.push(categoryId)
            }
            else {
                selectedCategories.splice(index,1)
            }
            setChosenCategories(selectedCategories)
    }


    const onSubmit = (e) => {
        e.preventDefault();
        const formData = new FormData();
        
        formData.append("title", title);
        chosenCategories.forEach(id => formData.append('CategoryIds', id));
        formData.append("content", content);
        formData.append("price", price);
        formData.append("userProfileId", loggedInUser.id);
    
        if (id) {
            // If an image is chosen, use it; otherwise, use the original image
            if (image) {
                formData.append("formFile", image);
            } else if (originalImage) {
                const byteCharacters = atob(originalImage);
                const byteNumbers = new Array(byteCharacters.length);
                for (let i = 0; i < byteCharacters.length; i++) {
                    byteNumbers[i] = byteCharacters.charCodeAt(i);
                }
                const byteArray = new Uint8Array(byteNumbers);
                formData.append("formFile", new Blob([byteArray]));
            }
    
            updateListing(parseInt(id), formData)
                .then(() => navigate(`../`))
        } else {
            // For creating a new listing, only use the image if it's present
            if (image) {
                formData.append("formFile", image);
            }
    
            createListing(formData).then(() => {navigate("/listings")})
           
        }
    };
    
    return (
      
   <PageContainer>
        <Form onSubmit={(e) => {onSubmit(e)}}>
            <FormGroup>
                <Label>
                    Title
                </Label>
                <Input
                required
                value={title}
                placeholder="Enter the Title for the Listing"
                style={{width: "100%"}}
                onChange={(e) => {setTitle(e.target.value)}}
                />
            </FormGroup>
            
            <Label>Category (choose one or more)</Label>
            <Row>
            {categories?.map((c) => (
                <Col key={c.id} xs="auto">
                <FormGroup check>
                    <Label check>
                    <Input
                        type="checkbox"
                        value={c.id}
                        checked = {chosenCategories.includes(c.id)}
                        onChange={() => handleCheckBoxChange(c.id)}
                    />
                    {c.name}
                    </Label>
                </FormGroup>
                </Col>
            ))}
            </Row>
          
            <FormGroup>
                <Label>Price</Label>
                <Input
                required
                type="number"
                 step="0.01"
                 min="0"
                 value={price}
                placeholder="Enter a price (a dollar amount)"
                onChange={(e) => {setPrice(e.target.value)}}/>
            </FormGroup>
            <FormGroup>
                <Label>Content</Label>
                <Input
                value={content}
                required
                placeholder="Add a description of your itme"
                onChange={(e) => {setContent(e.target.value)}}/>
            </FormGroup>
            <FormGroup>
                <Label>Image</Label>
                <Input
                type="file"
               
                onChange={(e) => {setImage(e.target.files[0])}}/>
            </FormGroup>
            {imagePreview && <img src={imagePreview} alt="Preview" style={{ maxWidth: "50%", height: "auto" }} />}
            {id ? (
                <Button type="submit" style={{float: "right"}} color="primary">Save</Button>
            ) :(
                <Button type="submit" style={{float: "right"}} color="primary">
            Post
        </Button>
            )}
       </Form>
   </PageContainer>
      
    )
}