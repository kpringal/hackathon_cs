import React, { FC, useState } from 'react';
import styles from './DrawGrid.module.css';

interface DrawGridProps {
  reserved: any;
  selected: any;
  seat: any;
}

function DrawGrid(props:DrawGridProps)
{

  const[state , setState]=  useState<any>();

  function onClickData(seat: any) {
    if (state.seatReserved.indexOf(seat) > -1) {
      setState({
        seatAvailable: state.seatAvailable.concat(seat),
        seatReserved: state.seatReserved.filter((res: any) => res != seat)
        //seatSelected: this.state.seatSelected.filter(res => res != seat)
      });
    } else {
      setState({
        seatReserved: state.seatReserved.concat(seat),
        //seatSelected: this.state.seatSelected.concat(seat),
        seatAvailable: state.seatAvailable.filter((res: any) => res != seat)
      });
    }
  }
  function checktrue(row: any) {
    if (state.seatSelected.indexOf(row) > -1) {
      return false;
    } else {
      return true;
    }
  }

  function handleSubmited() {
    setState({
      seatSelected: state.seatSelected.concat(state.seatReserved)
    });
    setState({
      seatReserved: []
    });
  }

  function onClickSeat(seat: any) {
    onClickData(seat);
  }

  return(
  <div className="container">
  <h2 />
  <table className="grid">
    <tbody>
      <tr>
        {props.seat.map((row:any) => (
          <td
            className={
              props.selected.indexOf(row) > -1
                ? "reserved"
                : props.reserved.indexOf(row) > -1
                ? "selected"
                : "available"
            }
            key={row}
            onClick={()=>
              checktrue(row)
                ? () => onClickSeat(row)
                : null
            }
          >
            {row}{" "}
          </td>
        ))}
      </tr>
    </tbody>
  </table>
  <button
    type="button"
    className="btn-success btnmargin"
    onClick={() => handleSubmited()}
  >
    Confirm Booking
  </button>
</div>
);
          }

export default DrawGrid;
