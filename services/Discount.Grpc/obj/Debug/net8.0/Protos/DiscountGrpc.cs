// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/discount.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Discount.Grpc {
  public static partial class DiscountProtoService
  {
    static readonly string __ServiceName = "greet.DiscountProtoService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Discount.Grpc.GetDiscountRequest> __Marshaller_greet_GetDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.Grpc.GetDiscountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Discount.Grpc.CouponModel> __Marshaller_greet_CouponModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.Grpc.CouponModel.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Discount.Grpc.CreateDiscountRequest> __Marshaller_greet_CreateDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.Grpc.CreateDiscountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Discount.Grpc.UpdateDiscountRequest> __Marshaller_greet_UpdateDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.Grpc.UpdateDiscountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Discount.Grpc.DeleteDiscountRequest> __Marshaller_greet_DeleteDiscountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.Grpc.DeleteDiscountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Discount.Grpc.DeleteDiscountResponse> __Marshaller_greet_DeleteDiscountResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Discount.Grpc.DeleteDiscountResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Discount.Grpc.GetDiscountRequest, global::Discount.Grpc.CouponModel> __Method_GetDiscount = new grpc::Method<global::Discount.Grpc.GetDiscountRequest, global::Discount.Grpc.CouponModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetDiscount",
        __Marshaller_greet_GetDiscountRequest,
        __Marshaller_greet_CouponModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Discount.Grpc.CreateDiscountRequest, global::Discount.Grpc.CouponModel> __Method_CreateDiscount = new grpc::Method<global::Discount.Grpc.CreateDiscountRequest, global::Discount.Grpc.CouponModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateDiscount",
        __Marshaller_greet_CreateDiscountRequest,
        __Marshaller_greet_CouponModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Discount.Grpc.UpdateDiscountRequest, global::Discount.Grpc.CouponModel> __Method_UpdateDiscount = new grpc::Method<global::Discount.Grpc.UpdateDiscountRequest, global::Discount.Grpc.CouponModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateDiscount",
        __Marshaller_greet_UpdateDiscountRequest,
        __Marshaller_greet_CouponModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Discount.Grpc.DeleteDiscountRequest, global::Discount.Grpc.DeleteDiscountResponse> __Method_DeleteDiscount = new grpc::Method<global::Discount.Grpc.DeleteDiscountRequest, global::Discount.Grpc.DeleteDiscountResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteDiscount",
        __Marshaller_greet_DeleteDiscountRequest,
        __Marshaller_greet_DeleteDiscountResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Discount.Grpc.DiscountReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of DiscountProtoService</summary>
    [grpc::BindServiceMethod(typeof(DiscountProtoService), "BindService")]
    public abstract partial class DiscountProtoServiceBase
    {
      /// <summary>
      /// Discount CRUD Operations
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Discount.Grpc.CouponModel> GetDiscount(global::Discount.Grpc.GetDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Discount.Grpc.CouponModel> CreateDiscount(global::Discount.Grpc.CreateDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Discount.Grpc.CouponModel> UpdateDiscount(global::Discount.Grpc.UpdateDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Discount.Grpc.DeleteDiscountResponse> DeleteDiscount(global::Discount.Grpc.DeleteDiscountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(DiscountProtoServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetDiscount, serviceImpl.GetDiscount)
          .AddMethod(__Method_CreateDiscount, serviceImpl.CreateDiscount)
          .AddMethod(__Method_UpdateDiscount, serviceImpl.UpdateDiscount)
          .AddMethod(__Method_DeleteDiscount, serviceImpl.DeleteDiscount).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, DiscountProtoServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.Grpc.GetDiscountRequest, global::Discount.Grpc.CouponModel>(serviceImpl.GetDiscount));
      serviceBinder.AddMethod(__Method_CreateDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.Grpc.CreateDiscountRequest, global::Discount.Grpc.CouponModel>(serviceImpl.CreateDiscount));
      serviceBinder.AddMethod(__Method_UpdateDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.Grpc.UpdateDiscountRequest, global::Discount.Grpc.CouponModel>(serviceImpl.UpdateDiscount));
      serviceBinder.AddMethod(__Method_DeleteDiscount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Discount.Grpc.DeleteDiscountRequest, global::Discount.Grpc.DeleteDiscountResponse>(serviceImpl.DeleteDiscount));
    }

  }
}
#endregion
