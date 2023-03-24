import { Typography, TextField, Button } from '@mui/material'
import { Stack } from '@mui/system'
import { useState } from 'react'

export interface Iprops {
    iTitle?:string
    iPrice?: number|undefined
    iDescription?: string
    iCategory?: string|undefined
    iImages?: string[]
    buttonLabel?: string
    cancelButtonLabel?:string
    onUpdateProduct:(title:string, price:number, description:string, category:string)=>void
    cancelBtn:()=>void
}

const EditProduct = ({iTitle, iPrice, iDescription, iCategory, cancelBtn, buttonLabel, cancelButtonLabel, onUpdateProduct}:Iprops) => {
    const [title, setTitle] = useState<string|undefined>(iTitle)
    const [price, setPrice] = useState<number|undefined>(iPrice)
    const [description, setDescription] = useState<string|undefined>(iDescription)
    const [category, setCategory] = useState<string|undefined>(iCategory)
    // const [images, setImages] = useState([])

    const onBtnSubmit = (e: any) => {
        e.preventDefault()
        onUpdateProduct(title?title:'', price?price:0, description?description:'', category?category:'')
    }
    
    return (
        <form onSubmit={(e) => onBtnSubmit(e)}>
            <Stack spacing={1} padding='20px' sx={{ width: '500px', border: '2px solid grey' }}>
                <Typography align='center' variant='h4' > Update Product  </Typography>
                <TextField variant='outlined' type='text' label='Title' defaultValue={title} onChange={(e => setTitle(e.target.value))}></TextField>
                <TextField variant='outlined' label='Price' defaultValue={price} type='number' onChange={(e => setPrice(parseInt(e.target.value)))} ></TextField>
                <TextField defaultValue={description} variant='outlined' label='Description' type='text' onChange={(e => setDescription(e.target.value))}></TextField>
                <TextField defaultValue={category} type='text' variant='outlined' label='Category' onChange={(e => setCategory(e.target.value))}></TextField>
                <TextField variant="outlined" label="Upload Images" disabled ></TextField>
                {/* <TextField value={singleProduct?.images} type='file' inputProps={{ multiple: true }}></TextField> */}
                <Button type="submit" sx={{ bgcolor: '#FFC108' }} variant='contained'>{buttonLabel}</Button>
                <Button onClick={cancelBtn} type="submit" sx={{ bgcolor: '#FFC108' }} variant='contained'>{cancelButtonLabel}</Button>          
            </Stack>
        </form>
    )
}

export default EditProduct