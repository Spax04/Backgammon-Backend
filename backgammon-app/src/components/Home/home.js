import { NavLink } from 'react-router-dom'

function Home () {
  return (
    <div className='container'>
      <div >
        <h1 className='text-center mt-5'>Welcome to Backgammon online game</h1>
        <NavLink className='btn btn-success pt-3 mt-5 w-100' to='/startgame'>Start</NavLink>
      </div>
    </div>
  )
}
export default Home
