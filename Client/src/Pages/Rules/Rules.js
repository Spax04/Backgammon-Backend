import { NavLink } from 'react-router-dom'
import { useState } from 'react'
import '../Login/Login.css'
import IdentityService from '../../services/IdentityService'
import { useNavigate } from 'react-router-dom'
import Accordion from 'react-bootstrap/Accordion'

const Rules = props => {
  return (
    <Accordion defaultActiveKey='0'>
      <Accordion.Item eventKey='0'>
        <Accordion.Header>Setup</Accordion.Header>
        <Accordion.Body>
          Backgammon is a game for two players, played on a board consisting of
          twenty-four narrow triangles called points. The triangles alternate in
          color and are grouped into four quadrants of six triangles each. The
          quadrants are referred to as a player's home board and outer board,
          and the opponent's home board and outer board. The home and outer
          boards are separated from each other by a ridge down the center of the
          board called the bar. Figure 1. A board with the checkers in their
          initial position. An alternate arrangement is the reverse of the one
          shown here, with the home board on the left and the outer board on the
          right. The points are numbered for either player starting in that
          player's home board. The outermost point is the twenty-four point,
          which is also the opponent's one point. Each player has fifteen
          checkers of his own color. The initial arrangement of checkers is: two
          on each player's twenty-four point, five on each player's thirteen
          point, three on each player's eight point, and five on each player's
          six point. Both players have their own pair of dice and a dice cup
          used for shaking. A doubling cube, with the numerals 2, 4, 8, 16, 32,
          and 64 on its faces, is used to keep track of the current stake of the
          game.
          <img src='https://www.bkgm.com/rules/rulfig1.gif'></img>
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='1'>
        <Accordion.Header>Object of the Game</Accordion.Header>
        <Accordion.Body>
          The object of the game is move all your checkers into your own home
          board and then bear them off. The first player to bear off all of
          their checkers wins the game.
          <img src='https://www.bkgm.com/rules/rulfig2.gif'></img>
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='2'>
        <Accordion.Header>Movement of the Checkers</Accordion.Header>
        <Accordion.Body>
          To start the game, each player throws a single die. This determines
          both the player to go first and the numbers to be played. If equal
          numbers come up, then both players roll again until they roll
          different numbers. The player throwing the higher number now moves his
          checkers according to the numbers showing on both dice. After the
          first roll, the players throw two dice and alternate turns. The roll
          of the dice indicates how many points, or pips, the player is to move
          his checkers. The checkers are always moved forward, to a
          lower-numbered point. The following rules apply: <br />
          1. A checker may be moved only to an open point, one that is not
          occupied by two or more opposing checkers. <br />
          2.The numbers on the two dice constitute separate moves. For example,
          if a player rolls 5 and 3, he may move one checker five spaces to an
          open point and another checker three spaces to an open point, or he
          may move the one checker a total of eight spaces to an open point, but
          only if the intermediate point (either three or five spaces from the
          starting point) is also open.
          <img src='https://www.bkgm.com/rules/rulfig3.gif'></img> <br />
          3.A player who rolls doubles plays the numbers shown on the dice
          twice. A roll of 6 and 6 means that the player has four sixes to use,
          and he may move any combination of checkers he feels appropriate to
          complete this requirement. <br />
          4.A player must use both numbers of a roll if this is legally possible
          (or all four numbers of a double). When only one number can be played,
          the player must play that number. Or if either number can be played
          but not both, the player must play the larger one. When neither number
          can be used, the player loses his turn. In the case of doubles, when
          all four numbers cannot be played, the player must play as many
          numbers as he can.
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='3'>
        <Accordion.Header>Hitting and Entering</Accordion.Header>
        <Accordion.Body>
          A point occupied by a single checker of either color is called a blot.
          If an opposing checker lands on a blot, the blot is hit and placed on
          the bar. Any time a player has one or more checkers on the bar, his
          first obligation is to enter those checker(s) into the opposing home
          board. A checker is entered by moving it to an open point
          corresponding to one of the numbers on the rolled dice. For example,
          if a player rolls 4 and 6, he may enter a checker onto either the
          opponent's four point or six point, so long as the prospective point
          is not occupied by two or more of the opponent's checkers.
          <br />
          <img src='https://www.bkgm.com/rules/rulfig4.gif'></img> <br />
          If neither of the points is open, the player loses his turn. If a
          player is able to enter some but not all of his checkers, he must
          enter as many as he can and then forfeit the remainder of his turn.
          After the last of a player's checkers has been entered, any unused
          numbers on the dice must be played, by moving either the checker that
          was entered or a different checker.
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='4'>
        <Accordion.Header>Bearing Off</Accordion.Header>
        <Accordion.Body>
          Once a player has moved all of his fifteen checkers into his home
          board, he may commence bearing off. A player bears off a checker by
          rolling a number that corresponds to the point on which the checker
          resides, and then removing that checker from the board. Thus, rolling
          a 6 permits the player to remove a checker from the six point. If
          there is no checker on the point indicated by the roll, the player
          must make a legal move using a checker on a higher-numbered point. If
          there are no checkers on higher-numbered points, the player is
          permitted (and required) to remove a checker from the highest point on
          which one of his checkers resides. A player is under no obligation to
          bear off if he can make an otherwise legal move.
          <br />
          <img src='https://www.bkgm.com/rules/rulfig5.gif'></img> <br />A
          player must have all of his active checkers in his home board in order
          to bear off. If a checker is hit during the bear-off process, the
          player must bring that checker back to his home board before
          continuing to bear off. The first player to bear off all fifteen
          checkers wins the game.
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='5'>
        <Accordion.Header>Doubling</Accordion.Header>
        <Accordion.Body>
          Backgammon is played for an agreed stake per point. Each game starts
          at one point. During the course of the game, a player who feels he has
          a sufficient advantage may propose doubling the stakes. He may do this
          only at the start of his own turn and before he has rolled the dice. A
          player who is offered a double may refuse, in which case he concedes
          the game and pays one point. Otherwise, he must accept the double and
          play on for the new higher stakes. A player who accepts a double
          becomes the owner of the cube and only he may make the next double.
          Subsequent doubles in the same game are called redoubles. If a player
          refuses a redouble, he must pay the number of points that were at
          stake prior to the redouble. Otherwise, he becomes the new owner of
          the cube and the game continues at twice the previous stakes. There is
          no limit to the number of redoubles in a game.
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='6'>
        <Accordion.Header>Gammons and Backgammons</Accordion.Header>
        <Accordion.Body>
          At the end of the game, if the losing player has borne off at least
          one checker, he loses only the value showing on the doubling cube (one
          point, if there have been no doubles). However, if the loser has not
          borne off any of his checkers, he is gammoned and loses twice the
          value of the doubling cube. Or, worse, if the loser has not borne off
          any of his checkers and still has a checker on the bar or in the
          winner's home board, he is backgammoned and loses three times the
          value of the doubling cube.
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='7'>
        <Accordion.Header>Optional Rules</Accordion.Header>
        <Accordion.Body>
          The following optional rules are in widespread use.
          <br />
          1. Automatic doubles.
          <br />
          If identical numbers are thrown on the first roll, the stakes are
          doubled. The doubling cube is turned to 2 and remains in the middle.
          Players usually agree to limit the number of automatic doubles to one
          per game.
          <br />
          2. Beavers.
          <br />
          When a player is doubled, he may immediately redouble (beaver) while
          retaining possession of the cube. The original doubler has the option
          of accepting or refusing as with a normal double.
          <br />
          3. The Jacoby Rule.
          <br />
          Gammons and backgammons count only as a single game if neither player
          has offered a double during the course of the game. This rule speeds
          up play by eliminating situations where a player avoids doubling so he
          can play on for a gammon.
        </Accordion.Body>
      </Accordion.Item>
      <Accordion.Item eventKey='8'>
        <Accordion.Header>Irregularities</Accordion.Header>
        <Accordion.Body>
          1. The dice must be rolled together and land flat on the surface of
          the right-hand section of the board. The player must reroll both dice
          if a die lands outside the right-hand board, or lands on a checker, or
          does not land flat.
          <br />
          2. A turn is completed when the player picks up his dice. If the play
          is incomplete or otherwise illegal, the opponent has the option of
          accepting the play as made or of requiring the player to make a legal
          play. A play is deemed to have been accepted as made when the opponent
          rolls his dice or offers a double to start his own turn.
          <br />
          3. If a player rolls before his opponent has completed his turn by
          picking up the dice, the player's roll is voided. This rule is
          generally waived any time a play is forced or when there is no further
          contact between the opposing forces.
        </Accordion.Body>
      </Accordion.Item>
    </Accordion>
  )
}

export default Rules
