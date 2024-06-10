import { Button, Dropdown, DropdownToggle, Form, FormGroup, Input, Label } from "reactstrap";
import PageContainer from "../PageContainer.jsx";
import { useEffect, useState } from "react";
import { getAll } from "../../managers/categoryManager.js";

export default function ListingForm()
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


    const onSubmit = () => {
        const formData = new FormData()
        formData.append("formFile", image)
        formData.append("title", title)
        formData.append("categoryIds",categoryIds)
        formData.append("content", content)
        formData.append("price", price)

    }
    return (
      
   <PageContainer>
        <Form>
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
                {categories?.map((c) =>(
                    <FormGroup>
                        <Input
                        type="checkbox"
                        value={c.id}
                        onChange={() => handleCheckBoxChange(c.id)}
                        />
                        <Label>{c.name}</Label>

                    </FormGroup>
                ))}
          
            <FormGroup>
                <Label>Price</Label>
                <Input
                type="number"
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
        <Button style={{float: "right"}} color="primary">
            Post
        </Button>
       </Form>
   </PageContainer>
      
    )
}