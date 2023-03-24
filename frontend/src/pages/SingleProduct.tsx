import { TableContainer, Paper, Table, TableHead, TableRow, TableCell, Button, TableBody, Card, CardMedia, CardActions, Box} from '@mui/material'
import { AxiosResponse } from 'axios'
import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { v4 as uuidv4 } from 'uuid';

import { add } from '../redux/reducers/cartReducer'
import { deleteAproduct } from '../redux/reducers/productReducer'
import axiosInstance from '../shared/axiosInstance'
import { Product } from '../types/product'
import EditProduct from '../components/EditProduct'
import { modifyProduct } from '../redux/reducers/productReducer'

const SingleProduct = () => {
    const dispatch = useAppDispatch()
    const userAuthentication = useAppSelector(state => state.authenticationReducer)
    const [singleProduct, setSingleProduct] = useState<Product>()
    const [isEditing, setIsEditing] = useState(true)

    const { id} = useParams()
    const navigate = useNavigate()
    const reRoute = () => {
        navigate('/')
    }
    const reRouteToSingleProductPage = () => {
        setIsEditing(true)
        navigate(`/products/${id}`)
    }
    const editProduct = () => {
        setIsEditing(false)
    }
    useEffect(() => {
        axiosInstance.get(`products/${id}`)
            .then((response: AxiosResponse<Product, Error>) => {
                setSingleProduct(response.data)
            })
    }, [id])

    const addToCart = (product: Product) => {
        dispatch(add(product))
    }
    const deleteProduct=() =>{
        const productId= (singleProduct?.id)
        dispatch(deleteAproduct(productId))
        console.log(id, "Type:", typeof(productId))
    }
    
    const updateProduct = (title: string, price: number, description: string, category: string) => {
        const productToUpdate = { ...singleProduct, title, price, description, category }
        dispatch(modifyProduct({
            updateId: productToUpdate.id,
            update: {
                title: productToUpdate.title,
                price: productToUpdate.price,
                description: productToUpdate.description,
                category: productToUpdate.category
            }
        }))
        try {
            fetch(`https://api.escuelajs.co/api/v1/products/${id}`)
                .then(response => response.json())
                .then(data => setSingleProduct(data))
            setIsEditing(true)
        } catch (error) {
            console.log(error)
        }
    }

    return (
    <TableContainer component={Paper}
        sx={{
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
            justifySelf: 'center',
            width: '100%',
            position: 'relative'
        }}>
        {isEditing ?
            <Box sx={{
                margin: '5%',
                width: '50%',
                overflow: 'hidden',
                padding: '20px'
            }}>
                {singleProduct ? <Button onClick={() => (reRoute())} sx={{ color: '#1a5db6' }} variant='text'> <ArrowBackIcon /> </Button> : <Button></Button>}
                <Card sx={{ display: 'flex', justifyContent: 'space-around', margin: '10px', padding: '5px' }}>
                    {singleProduct?.images.map((image) => <CardMedia key={uuidv4()} sx={{ height: 400, width: 400 }} image={image.url} />)}
                </Card>
                <Table >
                        <TableHead  >
                            <TableRow>
                                <TableCell></TableCell>
                                <TableCell></TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <TableRow>
                                <TableCell>
                                    {'Name'}
                                </TableCell>
                                <TableCell>
                                    {singleProduct?.title}
                                </TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    {'Price '}
                                </TableCell>
                                <TableCell>
                                    € {singleProduct?.price}
                                </TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    {'Description'}
                                </TableCell>
                                <TableCell >
                                    {singleProduct?.description}
                                </TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    {'Category'}
                                </TableCell>
                                <TableCell >
                                    {singleProduct?.category.name}
                                </TableCell>
                            </TableRow>
                        </TableBody>
                </Table>
                <CardActions>
                    {singleProduct ? <Button onClick={() => addToCart(singleProduct)} sx={{ bgcolor: '#FFC108' }} variant='contained'> Add To Cart </Button> : <Button>Add to Cart</Button>}
                    {singleProduct && userAuthentication.isAuthenticated && userAuthentication.user?.role === 'admin' ? 
                    <Button onClick={editProduct} sx={{ bgcolor: '#FFC108' }} variant='contained'> Edit </Button> : ''}
                    {singleProduct && userAuthentication.isAuthenticated && userAuthentication.user?.role === 'admin' ? 
                    <Button onClick={deleteProduct} sx={{ bgcolor: '#FFC108' }} variant='contained'> Delete </Button> 
                    : ''}
                </CardActions>
            </Box> :
            <Box sx={{
                margin: '5%',
                width: '50%',
                overflow: 'hidden',
                padding: '20px'
            }}>
                <EditProduct
                    cancelButtonLabel='Cancel' buttonLabel='Update' onUpdateProduct={updateProduct} cancelBtn={reRouteToSingleProductPage}
                    iTitle={singleProduct?.title}
                    iPrice={singleProduct?.price}
                    iDescription={singleProduct?.description}
                    iCategory={singleProduct?.category.name}
                />
            </Box>
        }
    </TableContainer>
    )
}

export default SingleProduct