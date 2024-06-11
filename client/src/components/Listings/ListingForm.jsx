import { Button, Col, Dropdown, DropdownToggle, Form, FormGroup, Input, Label, Row } from "reactstrap";
import PageContainer from "../PageContainer.jsx";
import { useEffect, useState } from "react";
import { getAll } from "../../managers/categoryManager.js";
import { createListing } from "../../managers/listingManger.js";

export default function ListingForm({loggedInUser})
{
    const [categories, setCategories] = useState()
    const [title, setTitle] = useState("")
    const [categoryIds, setCategoryIds] = useState([])
    const [content, setContent] = useState("")
    const [price, setPrice] = useState(0)
    const [image, setImage] = useState()
    const [chosenCategories, setChosenCategories] = useState([])

    useEffect(() => {
        getAll().then(setCategories)
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
        e.preventDefault()
        const formData = new FormData()
        formData.append("formFile", image)
        formData.append("title", title)
        chosenCategories.forEach(id => formData.append('CategoryIds', id));
        formData.append("content", content)
        formData.append("price", price)
        formData.append("userProfileId", loggedInUser.id)


        createListing(formData)
    .then(data => {
        console.log('Success:', data);
    })
    .catch(error => {
        console.error('Error:', error);
    });
    }
    return (
      
   <PageContainer>
        <Form onSubmit={(e) => {onSubmit(e)}}>
            <FormGroup>
                <Label>
                    Title
                </Label>
                <Input
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
                type="number"
                 step="0.01"
                 min="0"
                placeholder="Enter a price (a dollar amount)"
                onChange={(e) => {setPrice(e.target.value)}}/>
            </FormGroup>
            <FormGroup>
                <Label>Content</Label>
                <Input
                placeholder="Add a description of your itme"
                onChange={(e) => {setContent(e.target.value)}}/>
            </FormGroup>
            <FormGroup>
                <Label>Image</Label>
                <Input
                type="file"
                onChange={(e) => {setImage(e.target.files[0])}}/>
            </FormGroup>
        <Button type="submit" style={{float: "right"}} color="primary">
            Post
        </Button>
       </Form>
   </PageContainer>
      
    )
}