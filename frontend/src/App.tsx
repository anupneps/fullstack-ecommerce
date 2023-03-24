import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

import Home from './pages/Home';
import Cart from './pages/Cart';
import Navbar from './components/Navbar';
import Register from './components/Register';
import LoginIn from './components/LoginIn';
import Profile from './pages/Profile';
import SingleProduct from './pages/SingleProduct';
import Footer from './pages/Footer';
import Categories from './components/Categories';
import PageNotFound from './pages/PageNotFound';
import { useAppSelector } from './hooks/reduxHook';
import AdminPage from './pages/Admin';
import { About } from './pages/About';

const App = () => {
  const userAuthentication = useAppSelector(state => state.authenticationReducer)
  return (
    <BrowserRouter>
      <Navbar title='Anp' />
      <Routes>
        <Route path='/' element={<Home />}></Route>
        <Route path='/about' element={<About />}></Route>
        <Route path='/cart' element={<Cart />}></Route>
        <Route path='/categories' element={<Categories />}></Route>
        <Route path='/signup' element={<Register />}></Route>
        <Route path='/login' element={<LoginIn />}></Route>
        <Route path="/products/:id" element={<SingleProduct />}></Route>
        <Route path='/*' element={<PageNotFound />}></Route>
        <Route path = '/createproduct' element = {<AdminPage/>}></Route>
        <Route path='/profile'
          element={userAuthentication.isAuthenticated ? <Profile /> : <Navigate replace to={"/login"} />}
        />
        {/* <Route path='/admin' element={<AdminPage/>}></Route> */}
        <Route path='/admin'
          element={userAuthentication.isAuthenticated && userAuthentication.user?.role === 'admin' ?
            <AdminPage /> : <Navigate replace to={"/404"} />}
        />
      </Routes>
      <Footer />
    </BrowserRouter >
    
  )
}
export default App;