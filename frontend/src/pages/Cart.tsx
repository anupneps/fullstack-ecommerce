import { Box, Button, Card, CardActions, CardContent, CardMedia, Grid, Link } from '@mui/material';
import Typography from '@mui/material/Typography';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import DeleteSweepTwoToneIcon from '@mui/icons-material/DeleteSweepTwoTone';
import AddTwoToneIcon from '@mui/icons-material/AddTwoTone';
import RemoveTwoToneIcon from '@mui/icons-material/RemoveTwoTone';

import { increment, decrement, remove } from '../redux/reducers/cartReducer';
import { Product } from '../types/product';


const Cart: React.FC = () => {
   let navigate = useNavigate();
   const routeChange = () => {
      navigate('/');
   }

   const [total, setTotal] = useState<number>(0)
   const cartItems = useAppSelector(state => state.cartReducer)
   const dispatch = useAppDispatch()

   const deleteItem = (product: Product) => {
      dispatch(remove(product))
   }

   const handleAddCounter = (productId: Product) => {
      dispatch(increment(productId))
   }

   const handleMinusCounter = (productId: Product) => {
      dispatch(decrement(productId))
   }

   useEffect(() => {
      setTotal(cartItems.cart.reduce((acc, cur) => {
         let sum = 0
         if (cur.subTotal) {
            sum = acc + cur.subTotal
         }
         return sum
      }, 0))
   }, [cartItems.cart])

   return (
      <>
         <Box mb={8} px={4} marginTop='40px' marginBottom='5%' width={'100%'} height={'100vh'} >
            <Typography fontFamily={'georgia,serif'} variant='h4'>
               Shopping Cart
            </Typography>
            <Typography fontFamily={'georgia,serif'} variant='h6' marginTop='40px' marginBottom={'40px'}>
               You have got {cartItems.cart.length} products in Cart
            </Typography>
            <Grid item display={'flex'} flexDirection='row' xs={10} md={8} gap={8} >
               <Grid item display={'flex'} flexDirection='column' justifyContent={'space-evenly'} gap={2} width='100%' alignSelf={'center'}>
                  {cartItems.cart.map(product => (
                     <Card key={product.id} sx={{ cursor: 'pointer', display: 'flex', padding: '10px' }}>
                        <CardMedia
                           sx={{ height: 200, width: 200 }}
                           image={product.images[0].url}
                        />
                        <CardContent sx={{ textAlign: 'left', width: '40%', padding: '10px' }}>
                           <Typography variant='body2' gutterBottom  >
                              {product.title}
                           </Typography>
                           <Typography variant='h6' fontWeight={'400'}>
                              € {product.price}
                           </Typography>
                        </CardContent>
                        <CardActions sx={{ padding: '10px', width: '20%', display: 'flex', justifyContent: 'center' }}  >
                           <Button onClick={() => (handleAddCounter(product))} sx={{color:'#A88D5C', border:'1px solid #A88D5C'}} variant='outlined' > <AddTwoToneIcon/> </Button>
                           <Typography fontFamily={'georgia,serif'} variant='h6' padding={'5px'} >{product.quantity}</Typography>
                           <Button onClick={() => handleMinusCounter(product)} sx={{color:'#A88D5C', border:'1px solid #A88D5C'}} variant='outlined' > <RemoveTwoToneIcon/> </Button>
                        </CardActions>
                        <Box padding={'10px'} width='20%'>
                           <Typography fontFamily={'georgia,serif'} variant='body2'>SubTotal(€):{(product.subTotal ? product.subTotal : product.price).toFixed(2)}</Typography>
                        </Box>
                        <CardActions>
                           <Button onClick={() => deleteItem(product)} sx={{color:'#A88D5C', border:'1px solid #A88D5C'}} variant='outlined' > <DeleteSweepTwoToneIcon/> </Button>
                        </CardActions>
                     </Card>
                  ))}
               </Grid>

               <Box width={'50%'} padding='20px' alignItems='center' height={'max-content'} flexDirection='column' justifyContent={'center'}
               sx={{boxShadow:'rgba(17, 12, 46, 0.15) 0px 48px 100px 0px;'}} >
                  {cartItems.cart.length < 1 ? <Typography fontFamily={'georgia,serif'} variant='h6' margin={'10px'}>Your cart is empty !</Typography> :
                     <>
                        <Typography fontFamily={'georgia,serif'} variant='h5' fontWeight={'700'} marginBottom={'20px'}>Summary</Typography>
                        <Typography fontFamily={'georgia,serif'} variant='h6' fontWeight={'700'} margin={'10px'}>Total items: <span style={{ marginLeft: '20px' }} >
                           {cartItems.cart.length}</span> </Typography>
                        <Typography fontFamily={'georgia,serif'} variant='h6' fontWeight={'700'} margin={'10px'}>Total Price: <span style={{ marginLeft: '20px' }} >
                           € {total.toFixed(2)}</span></Typography>
                     </>}
                  {total ? <Button sx={{bgcolor:'#FFC108', margin: '10px', fontFamily:'georgia,serif'}} variant='contained'>CheckOut</Button> : ""}
                  <Link onClick={routeChange} sx={{ margin: '10px', cursor: 'pointer' }} fontFamily={'georgia,serif'}>Continue Shopping</Link>
               </Box>
            </Grid>
         </Box>
      </>
   )
};

export default Cart;

