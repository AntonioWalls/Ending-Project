import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { getAuction, deleteAuctions } from '../../../redux/actions/actionAuction';
import Swal from "sweetalert2";

export default function TableAuction({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { auctions } = useSelector((state) => state.getAuction);


  // Obtener la id del usuario. 
  const [id, setId] = useState(0);
  const gridRef = useRef();
  const onSelectionChanged = useCallback(() => {
    const selectedRows = gridRef.current.api.getSelectedRows();
    document.querySelector("#selectedRows").innerHTML =
      selectedRows.length === 1 ? selectedRows[0].fiscalia : "";

    setId(selectedRows[0].idRemate);
    console.log(id)

  }, []);



  useEffect(() => {
    dispatch(getAuction());
    console.log(auctions);
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idRemate', headerName: 'ID de Remate' },
    { field: 'idInmobiliaria', headerName: 'ID de Inmobiliaria' },
    { field: 'fiscalia', headerName: 'Fiscalia' },
    { field: 'estado', headerName: 'Estado' },
    { field: 'fecha', headerName: 'Fecha' },
    { field: 'descripcion', headerName: 'Descripcion' }
  ]);


  const handleNew = () => {
    showForm();
    idUserEdit(0);
  };

  // const handleEdit = () => {
  //   if (id) {
  //     idUserEdit(id);
  //     showForm();
  //   } else {
  //     alert('Seleccione un usuario para modificar');
  //   }
  // };

  const handleEdit = () => {
      console.log(id);
      if(id){
          idUserEdit(id);
          showForm();
      }else{
          alert('Seleccione un remate para modificar');
      }
  };

  const handleDelete = () => {

    if (id) {
      // Eliminar usuario seleccionado
      dispatch(deleteAuctions(id)).then(() => {
        Swal.fire({
          icon: "success",
          title: "Remate eliminado",
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
          dispatch(getAuction());
        });
      });
    } else {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Seleccione un remate para eliminar",
      });
      }
    // console.log(id);
    // if (id) {
    //   // Eliminar usuario seleccionado
    //   dispatch(deleteRealState(id))
    //     .then(() => {
    //       window.location.href = window.location.href;
    //     })
    // } else {
    //   alert("Seleccione un usuario para eliminar");
    // }
  };


  // ...

  return (

    // wrapping container with theme & size
    <div
      className="ag-theme-quartz" // applying the grid theme
      style={{ height: 500, width: 1202 }} // the grid will fill the size of the parent container
    >
      <Row >
        <Col>
          <Button variant='primary' onClick={handleNew}>Nuevo Remate</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Remate</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Remate</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Remate seleccionado: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      <AgGridReact
        ref={gridRef}
        rowData={auctions.response}
        columnDefs={colDefs}
        rowSelection={"single"}
        onSelectionChanged={onSelectionChanged}
      />
    </div>
  )
}